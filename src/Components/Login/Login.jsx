
import { useState } from "react";
import { useTranslation } from "react-i18next";
import styles from "./Login.module.css";
import { Link } from "react-router-dom";
import logo from '../../assets/Logo.jpeg'
const Login = () => {
  const { t } = useTranslation();

   const [form, setForm] = useState({
    username: "",
    password: "",
  });
const [errors, setErrors] = useState({});

   const validate = () => {
    let newErrors = {};

    if (!form.username.trim()) {
      newErrors.username = t("errors.usernameRequired");
    } else if (!/[\u0600-\u06FFa-zA-Z]{3,}/.test(form.username)) {
      newErrors.username = t("errors.usernameInvalid");
    }

    if (!form.password.trim()) {
      newErrors.password = t("errors.passwordRequired");
    } else if (form.password.length < 6) {
      newErrors.password = t("errors.password");
    }

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };


  const handleSubmit = (e) => {
    e.preventDefault();
    if (validate()) {
      console.log("Login submitted:", form);
      //
    }
  };

  return (
    <div className={`${styles.loginContainer}`}>
      <div className="mb-4" style={{ color: "white", fontSize: "36px" }}>

 
  <div>
    <img src={logo} alt="logo" height="200px" width="400px" />
  </div>

 
  <h4 className="mb-4" style={{ color: "white", fontSize: "36px" ,textAlign:"center"}}>
    {t("login.submit")}
  </h4>
     
      </div>

      <div className={`d-flex flex-column align-items-center gap-3 ${styles.inputWrapper}`}>
        <input
        name="username" 
          type="text"
          className={`form-control text-center ${styles.input}`}
          placeholder={t("login.usernamePlaceholder")}
              onChange={handleChange}
        />
    {errors.username && (
            <div className={styles.error}>{errors.username}</div>
          )}
        <input
        name="password"
          type="password"
          className={`form-control text-center ${styles.input}`}
          placeholder={t("login.passwordPlaceholder")}
             onChange={handleChange}
             
        />

         {errors.password && (
            <div className={styles.error}>{errors.password}</div>
          )}
      </div>
  <div style={{ marginTop: "8px" }}>
    <Link to={'/forgetPassword'} className={styles.forgotPassword}>
      {t("login.forgotPassword")}
    </Link>
  </div> 
      <button
        className={`btn mt-4 ${styles.submitBtn}`}
        onClick={handleSubmit}
      >
        {t("login.submit")}
      </button>
    </div>
  );
};

export default Login;
