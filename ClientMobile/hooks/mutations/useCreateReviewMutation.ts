import axios from "axios";
import { useMutation, useQueryClient } from "react-query";

import { CreateReview } from "../../types/review";
import { endpoints, queryKeys } from "../../constants/constants";
import { useLoading } from "../useLoading";
import { useNavigation } from "@react-navigation/native";
import { useUser } from "../useUser";

const createReview = (
  collocationID: number,
  review: CreateReview,
  token?: string
) =>
  axios.post(`${endpoints.createReview}${collocationID}`, review, {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  });

export const useCreateReviewMutation = () => {
  const { setLoading } = useLoading();
  const queryClient = useQueryClient();
  const { goBack } = useNavigation();
  const { user } = useUser();

  return useMutation(
    ({ collocationID, review }: { collocationID: number; review: CreateReview }) =>
      createReview(collocationID, review, user?.accessToken),
    {
      onMutate: () => {
        setLoading(true);
      },
      onSuccess: () => {
        queryClient.invalidateQueries(queryKeys.selectedCollocation);
      },
      onError: () => {
        alert("Unable to create review");
      },
      onSettled: () => {
        setLoading(false);
        goBack();
      },
    }
  );
};
