import React from "react";
import styles from "./CircleIndicator.module.css";
import { useTranslation } from "react-i18next";

const CircleIndicator = () => {
  const { t } = useTranslation();


  const titles = [
    t("circles.one"),
    t("circles.two"),
    t("circles.three"),
  ];

const colors = ["#28a745", "#dc3545", "#ffc107"];
  const values = [150, 75, 30];

  return (
  <div className="container mt-3">
      <div className={`${styles.flexRow}`}>
        {titles.map((title, index) => (
          <div key={index} className={`${styles.flexItem}`}>
            <div className={styles.circle}  style={{ color: colors[index] ,  border:`12px solid ${colors[index]}`  }}>
                {values[index]}</div>
            <div className={styles.title} style={{ color: colors[index] }}>{title}</div>
          </div>
        ))}
      </div>
    </div>


  );
};

export default CircleIndicator;
