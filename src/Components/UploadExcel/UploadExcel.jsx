import React, { useState, useRef } from "react";
import styles from "./UploadExcel.module.css";
import { useTranslation } from "react-i18next";

const UploadExcel = ({
  label = "Upload File",
  onChange,
  error,
}) => {
  const [fileName, setFileName] = useState("");
  const fileInputRef = useRef(null);
  const { t } = useTranslation();

  const handleFileChange = (e) => {
    const file = e.target.files[0];
    setFileName(file ? file.name : "");
    if (onChange) onChange(file);
  };

  return (
    <div className={styles.wrapper}>
      <button
        type="button"
        className={styles.button}
        onClick={() => fileInputRef.current.click()}
      >
      <i className="bi bi-cloud-arrow-up fs-3"></i>  {t("uploadExcel")}
      </button>

      <input
        id={name}
        name={name}
        type="file"
        ref={fileInputRef}
        style={{ display: "none" }}
        onChange={handleFileChange}
      />
      {error && <div className={styles.error}>{error}</div>}
    </div>
  );
};

export default UploadExcel;
