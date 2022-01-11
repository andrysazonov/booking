import React from "react";
import styles from "./table.module.css";

export const Table = () => {
  return (
    <div>
      <table>
        <thead>
          <tr>
            <th>Коворкинг</th>
            <th>Дата</th>
            <th>С</th>
            <th>До</th>
            <th>Стол</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>Куйбышева</td>
            <td>24.12.2021 </td>
            <td>15:30</td>
            <td>19:30</td>
            <td>Стол 5</td>
          </tr>
          
        </tbody>
      </table>
    </div>
  );
};
