import { useState } from "react";
import { useTranslation } from "react-i18next";
import { useLocation, useNavigate } from "react-router-dom";
import styles from "./ResetPassword.module.css"; 

const ResetPassword = () => {
  const { t } = useTranslation();

  const [form, setForm] = useState({
    password: "",
    confirmPassword: "",
  });
  // to ensure that there is no, 

//   const location = useLocation();
//   const navigate = useNavigate();
//   const params = new URLSearchParams(location.search);
// const token = params.get("token");

// useEffect(() => {
//   if (!token) {
//     navigate("/ForgetPassword");
//   }
// }, [token, navigate]);

  const [errors, setErrors] = useState({});
  const [message, setMessage] = useState("");

  const validate = () => {
    let newErrors = {};

    if (!form.password.trim()) {
      newErrors.password = t("errors.passwordRequired");
    } else if (form.password.length < 6) {
      newErrors.password = t("errors.password");
    }

    if (!form.confirmPassword.trim()) {
      newErrors.confirmPassword = t("errors.confirmPasswordRequired");
    } else if (form.confirmPassword !== form.password) {
      newErrors.confirmPassword = t("errors.confirmPassword");
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
      // Call API
      if (form.password === "123456") {
        setMessage(t("reset.success")); // مثال نجاح
      } else {
        setMessage(t("reset.error")); // مثال فشل
      }
    }
  };

  return (
    <div className={styles.loginContainer}>
      <h4
        className="mb-4"
        style={{ color: "white", fontSize: "28px", textAlign: "center" }}
      >
        {t("reset.title")}
      </h4>

      <div
        className={`d-flex flex-column align-items-center gap-3 ${styles.inputWrapper}`}
      >
        <input
          name="password"
          type="password"
          className={`form-control text-center ${styles.input}`}
          placeholder={t("reset.password")}
          value={form.password}
          onChange={handleChange}
        />
        {errors.password && <div className={styles.error}>{errors.password}</div>}

        <input
          name="confirmPassword"
          type="password"
          className={`form-control text-center ${styles.input}`}
          placeholder={t("reset.confirmPassword")}
          value={form.confirmPassword}
          onChange={handleChange}
        />
        {errors.confirmPassword && (
          <div className={styles.error}>{errors.confirmPassword}</div>
        )}
      </div>

      <button
        className={`btn mt-4 ${styles.submitBtn}`}
        onClick={handleSubmit}
      >
        {t("reset.submit")}
      </button>

      {message && (
        <div
          className="mt-3"
          style={{
            color: message.includes("تم") ? "lightgreen" : "#c11010ff",
            fontSize: "20px",
            fontWeight: "500",
          }}
        >
          {message}
        </div>
      )}
    </div>
  );
};

export default ResetPassword;
