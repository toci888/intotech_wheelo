import React from "react";
import { Pressable, ViewStyle, StyleSheet, TouchableOpacity, View, Modal, Dimensions, Image } from "react-native";
import { useState } from "react";
import { MaterialCommunityIcons } from "@expo/vector-icons";
import { Button } from "@ui-kitten/components";
import { useNavigation } from "@react-navigation/native";

import { CollocateAccount } from "../types/collocation";
import { ImageCarousel } from "./ImageCarousel";
import { CardInformation } from "./CardInformation";
import { LISTMARGIN, queryKeys } from "../constants/constants";
import { theme } from "../theme";
import { useDeleteCollocationMutation } from "../hooks/mutations/useDeleteCollocationMutation";
import useTheme from "../hooks/useTheme";

export const Card = ({
  collocation,
  onPress,
  myCollocation,
  style,
}: {
  collocation: CollocateAccount;
  onPress?: () => void;
  myCollocation?: boolean;
  style?: ViewStyle;
}) => {
  const {colors} = useTheme();
  const navigation = useNavigation();
  const [showModal, setShowModal] = useState(false);
  const openModal = () => setShowModal(true);
  const closeModal = () => setShowModal(false);
  const deleteCollocation = useDeleteCollocationMutation();
  
  const handleEditCollocation = () => {
    navigation.navigate("EditProperty", { collocationId: collocation.idAccount });
    closeModal();
  };

  const handleDeleteCollocation = () => {
    deleteCollocation.mutate({ collocationID: collocation.idAccount });
    closeModal();
  };
  
  return (
    <Pressable
      onPress={onPress} //TODO
      style={[styles.container, styles.boxShadow, style, {backgroundColor: colors.backgroundColor}]}
    >
      <ImageCarousel
        onImagePress={onPress}
        images={[collocation.image]}
        chevronsShown
      />

      <CardInformation collocation={collocation} myCollocation={myCollocation} />

      {myCollocation ? (
        <TouchableOpacity onPress={openModal} style={styles.ellipses}>
          <MaterialCommunityIcons
            name="dots-horizontal"
            color={theme["color-primary-500"]}
            size={30}
          />
        </TouchableOpacity>
      ) : null}

      <Modal visible={showModal} transparent>
        <View style={[styles.modal, styles.boxShadow]}>
          <Button
            status={"info"}
            appearance="ghost"
            onPress={handleEditCollocation}
          >
            Edit Collocation
          </Button>

          <Button
            status={"danger"}
            appearance="ghost"
            onPress={handleDeleteCollocation}
          >
            Delete Collocation
          </Button>
          <Button appearance="ghost" onPress={closeModal}>
            Cancel
          </Button>
        </View>
      </Modal>
    </Pressable>
  );
};

const styles = StyleSheet.create({
  container: {
    marginHorizontal: LISTMARGIN,
    borderRadius: 5,
    backgroundColor: "white",
  },
  ellipses: {
    backgroundColor: "#fff",
    position: "absolute",
    borderRadius: 5,
    paddingHorizontal: 5,
    top: 10,
    right: 15,
  },
  backdrop: {
    backgroundColor: "rgba(0, 0, 0, 0.5)",
  },
  modal: {
    backgroundColor: "#fff",
    borderRadius: 5,
    padding: 20,
    position: "absolute",
    top: Dimensions.get("screen").height / 3,
    right: Dimensions.get("screen").width / 4,
  },
  boxShadow: {
    shadowColor: "#000",
    shadowOffset: {
      width: 0,
      height: 5,
    },
    shadowOpacity: 0.34,
    shadowRadius: 6.27,
    elevation: 10,
  },
  image: {

  }
});
