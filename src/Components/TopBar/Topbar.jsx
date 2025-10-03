import { useContext } from "react";
import styles from "./Topbar.module.css";
import { AppContext } from "../../StateMangment";
import { useTranslation } from "react-i18next";

export default function Topbar() {
   const { switchLang} = useContext(AppContext);
     const { t ,i18n} = useTranslation();

       const toggleLang = () => {
    const newLang = i18n.language==='en'? "ar" : "en";
    switchLang(newLang);
  };

  return (
    <div className={styles.topbar}>
      <input type="text" className="form-control" placeholder="Search" />
      <div className={styles.actions} onClick={toggleLang}>
      <i className={`bi bi-globe-americas ${styles.avatar}  fs-2`} ></i><span>{i18n.language==='en'?"English":"عربى"}</span>
      </div>
    </div>
  );
}
