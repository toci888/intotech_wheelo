import React from "react";
import { StyleSheet, FlatList } from "react-native";
import { Text } from "@ui-kitten/components";
import { MaterialIcons } from "@expo/vector-icons";

import { CollocateAccount, Collocation } from "../../types/collocation";
import { Row } from "../Row";
import { PetCard } from "../PetCard";
import { GeneralTextCard } from "../GeneralTextCard";
import { CatsAndDogs, CatsOnly, DogsOnly } from "../../constants/petValues";
import { Driver } from "../../types";

export const LeaseAndFeesSection = ({ collocation }: { collocation: CollocateAccount }) => {
  const leaseLengths = [];
  const leaseLengthExists = new Map<string, boolean>();

  let minDeposit = collocation.latitudefrom;
  let maxDeposit = collocation.latitudeto;
  // for (let apartment of collocation.apartments) {
    if (collocation.latitudefrom > maxDeposit) maxDeposit = collocation.latitudefrom;
    if (collocation.latitudeto < minDeposit) minDeposit = collocation.latitudeto;

    if (!leaseLengthExists.get(collocation.phoneNumber)) {
      leaseLengths.push(collocation.phoneNumber);
      leaseLengthExists.set(collocation.phoneNumber, true);
    }
  // }

  let downDepositBody = [];
  if (minDeposit === maxDeposit) downDepositBody.push(`$${minDeposit}`);
  else {
    downDepositBody.push(`Min: $${minDeposit}`);
    downDepositBody.push(`Max: $${maxDeposit}`);
  }

  const getPetsAllowedText = () => {
    if (collocation.driver === Driver.driver) return "Cats and Dogs Allowed";
    if (collocation.driver === Driver.passenger) return "Only Cats Allowed";
    // if (collocation.petsAllowed === DogsOnly) return "Only Dogs Allowed";
    return "No Pets Allowed";
  };

  return (
    <>
      <Text category={"h5"} style={styles.defaultMarginVertical}>
        Lease Detail & Fees
      </Text>
      {collocation.driver === Driver.driver ? (
        <>
          <Row style={styles.row}>
            <MaterialIcons name="pets" color="black" size={24} />
            <Text category={"h6"} style={styles.rowText}>
              Pet Policies
            </Text>
          </Row>
          <GeneralTextCard heading="Pets" body={[getPetsAllowedText()]} />
        </>
      ) : null}
      {collocation.driver === Driver.driver ? (
        <>
          <Row style={styles.row}>
            <MaterialIcons name="attach-money" color="black" size={24} />
            <Text category={"h6"} style={styles.rowText}>
              Fees
            </Text>
          </Row>
          <GeneralTextCard
            heading="parking"
            body={[`${collocation.name}`]}
          />
        </>
      ) : null}

      <Row style={[styles.row, { paddingTop: 10 }]}>
        <MaterialIcons name="list-alt" color="black" size={24} />
        <Text category={"h6"} style={styles.rowText}>
          Details
        </Text>
      </Row>
      <FlatList
        style={styles.defaultMarginVertical}
        data={[
          {
            heading: "lease options",
            body: leaseLengths,
          },
          {
            heading: "Down Deposit",
            body: downDepositBody,
          },
        ]}
        horizontal
        showsHorizontalScrollIndicator={false}
        keyExtractor={(item) => item.heading}
        renderItem={({ item, index }) => (
          <GeneralTextCard
            heading={item.heading}
            body={item.body}
            style={styles.textCard}
          />
        )}
      />
    </>
  );
};

const styles = StyleSheet.create({
  defaultMarginVertical: { marginVertical: 10 },
  row: { alignItems: "center", marginVertical: 15 },
  rowText: { marginLeft: 10 },
  petCard: { marginRight: 15 },
  textCard: { marginRight: 10 },
});
