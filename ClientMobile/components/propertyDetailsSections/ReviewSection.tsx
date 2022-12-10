import React from "react";
import { FlatList, StyleSheet } from "react-native";
import { Text, Button } from "@ui-kitten/components";
import { useNavigation } from "@react-navigation/native";

import { CollocateAccount } from "../../types/collocation";
import { OverallReviewScoreCard } from "../OverallReviewScoreCard";
import { ReviewCard } from "../ReviewCard";
import { getStateAbbreviation } from "../../utils/getStateAbbreviation";
import { Review } from "../../types/review";

export const ReviewSection = ({ collocation }: { collocation: CollocateAccount }) => {
  const { navigate } = useNavigation();

  return (
    <>
      <Text category={"h5"} style={styles.defaultMarginVertical}>
        Reviews
      </Text>
      {collocation.name ? (
        <>
          <OverallReviewScoreCard
            numberOfReviews={collocation.name ? collocation.surname.length : 0}
            score={collocation.idAccount}
            style={styles.defaultMarginVertical}
          />
          <FlatList
            horizontal
            showsHorizontalScrollIndicator={false}
            style={styles.flatListMargin}
            data={[collocation.name, collocation.surname]}
            keyExtractor={(item) => item}
            renderItem={({ item }) => <ReviewCard review={{ item } as unknown as Review} />}
          />
        </>
      ) : (
        <Text>No reviews yet. Be the first one to review this collocation.</Text>
      )}

      <Button
        onPress={() =>
          navigate("Review", {
            collocationID: collocation.idAccount,
            collocationName: collocation?.name
              ? collocation.name
              : `${collocation.surname}, ${getStateAbbreviation(collocation.surname)}, ${
                  collocation.surname
                }`,
          })
        }
        style={styles.defaultMarginVertical}
      >
        Write a Review
      </Button>
    </>
  );
};

const styles = StyleSheet.create({
  defaultMarginVertical: { marginVertical: 10 },
  flatListMargin: { marginBottom: 50 },
});
