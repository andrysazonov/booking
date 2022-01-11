import React from "react";
import { Table } from "../../components/Table";
import  styles  from "./reservation.module.css";
export const ReservationsPage = () => {
  return (
    <div className={styles.page}>
      <h2>Мои записи</h2>
      <Table></Table>
    </div>
  );
};
