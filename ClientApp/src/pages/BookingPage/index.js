import React, { useState } from "react";
import { Map } from "../../components/Map";
import styles from "./booking.module.css";
import DatePicker, { registerLocale } from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import ru from "date-fns/locale/ru";
registerLocale("ru", ru);

export const BookingPage = () => {
  const [date, setDate] = useState(new Date());
  const [startTime, setStartTime] = useState();
  
  const sendTime()=>{

  }

  return (
    <div className={styles.bookingContainer}>
      <div className={styles.controlPanel}>
        Выберите дату
        <DatePicker
          dateFormat="dd.MM.yy"
          locale={"ru"}
          selected={date}
          onChange={(date) => setDate(date)}
        />
        Выберите время
        <DatePicker
          selected={date}
          onChange={(date) => setDate(date)}
          showTimeSelect
          showTimeSelectOnly
          timeIntervals={15}
          timeCaption="Time"
          dateFormat="HH:mm"
        />
        До скольки вы хотите забронировать
        <DatePicker
          selected={date}
          onChange={(date) => setDate(date)}
          showTimeSelect
          showTimeSelectOnly
          timeIntervals={15}
          timeCaption="Time"
          dateFormat="HH:mm"
        />
        <button className={styles.button}>Показать свободные столы</button>
        <button className={styles.buttonSubmit}>Заброинровать</button>
      </div>
      <div className={styles.bookingSide}>
        <div className={styles.map}>
          <Map />
        </div>
      </div>
    </div>
  );
};
