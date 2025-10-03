import { useState } from "react";
import { useTranslation } from "react-i18next";
import styles from "./ForgetPssword.module.css"; // استعملت نفس الستايل بتاع Login

const ForgotPassword = () => {
  const { t } = useTranslation();

  const [form, setForm] = useState({ email: "" });
  const [errors, setErrors] = useState({});
  const [message, setMessage] = useState("");

  const validate = () => {
    let newErrors = {};

    if (!form.email.trim()) {
      newErrors.email = t("errors.emailRequired");
    } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(form.email)) {
      newErrors.email = t("errors.email");
    }

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
    setMessage("");  
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (validate()) {
      //Api
      if (form.email === "test@test.com") {
        setMessage(t("forgot.success")); // success
      } else {
        setMessage(t("forgot.error")); // fail
      }
    }
  };

  return (
    <div className={`${styles.loginContainer}`}>
      <h4
        className="mb-4"
        style={{ color: "white", fontSize: "28px", textAlign: "center" }}
      >
        {t("forgot.title")}
      </h4>

      <div
        className={`d-flex flex-column align-items-center gap-3 ${styles.inputWrapper}`}
      >
        <input
          name="email"
          type="email"
          className={`form-control text-center ${styles.input}`}
          placeholder={t("register.email")}
          value={form.email}
          onChange={handleChange}
        />
        {errors.email && <div className={styles.error}>{errors.email}</div>}
      </div>

      <button
        className={`btn mt-4 ${styles.submitBtn}`}
        onClick={handleSubmit}
      >
        {t("forgot.submit")}
      </button>

      {message && (
        <div
          className="mt-3"
          style={{ color: message.includes("تم") ? "lightgreen" : "#c11010ff",fontSize:"20px",fontWeight:"500"}}
        >
          {message}
        </div>
      )}
    </div>
  );
};

export default ForgotPassword;
