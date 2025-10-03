import { useContext } from "react";
import styles from "./TopBarPath.module.css";
import { AppContext } from "../../StateMangment";
import { useTranslation } from "react-i18next";
import { NavLink  } from "react-router-dom";

export default function Topbar() {
   const { switchLang} = useContext(AppContext);
     const { t ,i18n} = useTranslation();

       const toggleLang = () => {
    const newLang = i18n.language==='en'? "ar" : "en";
    switchLang(newLang);
  };

  return (<>
    <div className={styles.topbar}>
      <div className="d-flex justify-content-center gap-5">
      <div className={styles.topbarpathitem}>
        <NavLink to={"/Editpath"}   end className={({ isActive }) => isActive ? styles.activeLink : ""}>{t("path.home")}</NavLink></div>
      <div><NavLink to={"/Editpath/pathEditInfo"}   className={({ isActive }) =>
    `${styles.topbarpathitem} ${isActive ? styles.activeLink : ""}`
  }>{t("path.pathInfo")} </NavLink> </div> 
      <div className={styles.topbarpathitem}>{t("path.events")}</div>
      </div>

      <div className={styles.actions} onClick={toggleLang}>
      <i className={`bi bi-globe-americas ${styles.avatar}  fs-2`} ></i><span>{i18n.language==='en'?"English":"عربى"}</span>
      </div>
    </div>
    </>
  );
}
