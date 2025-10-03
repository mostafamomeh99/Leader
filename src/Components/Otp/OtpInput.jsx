import React, { useState } from "react";
import { useTranslation } from "react-i18next";
import styles from "./OtpInput.module.css";

const OtpInput = () => {
  const [otp, setOtp] = useState(Array(6).fill(""));
  const { t } = useTranslation();
  const [error, setError] = useState("");

  const validate = () => {
    let newError = "";
const otpValue = otp.join("");
    if (!otpValue.trim()) {
      newError = t("errors.otpRequired");
    } else if (!/^\d{6}$/.test(otpValue)) {
      newError = t("errors.otp");
    }

    setError(newError);
    return newError === "";
  };

  const handleChange = (value, index) => {
    if (/^\d?$/.test(value)) {
      const newOtp = [...otp];
      newOtp[index] = value;
      setOtp(newOtp);

      const nextInput = document.getElementById(`otp-${index + 1}`);
      if (value && nextInput) {
        nextInput.focus();
      }
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if(!validate()) return;
  };

  return (
    <div className={`d-flex flex-column align-items-center`}>
      <h4 className="mb-4" style={{ color: "white", fontSize: "30px" }}>
        {t("otp.title")}
      </h4>
      <div
        className={`d-flex align-items-center justify-content-center gap-2 ${styles.otpWrapper}`}
      >
        {otp.map((digit, idx) => (
          <input
            key={idx}
            id={`otp-${idx}`}
            type="text"
            inputMode="numeric"
            maxLength={1}
            value={digit}
            onChange={(e) => handleChange(e.target.value, idx)}
            className={`form-control text-center ${styles.otpInput}`}
          />
        ))}
      </div>
               {error && <div className="text-danger fw-bold mt-1">{error}</div>}
      <button
        className={`btn mt-4 ${styles.submitBtn}`}
        onClick={handleSubmit}
      >
        {t("otp.submit")}
      </button>
    </div>
  );
};

export default OtpInput;
