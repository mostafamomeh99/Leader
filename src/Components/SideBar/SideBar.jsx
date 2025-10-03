
import { useTranslation } from "react-i18next";
import { useState, useContext } from "react";
import styles from "./Sidebar.module.css";
import "bootstrap-icons/font/bootstrap-icons.css";
import logo from '../../assets/Logo.jpeg'
import { AppContext } from "../../StateMangment";
import { Link } from "react-router-dom";
export default function SideBar() {
  const [open, setOpen] = useState(false);
  const [reportsOpen, setReportsOpen] = useState(false);
  const [operationsOpen, setOperationsOpen] = useState(false);
  const [managementOpen, setManagementOpen] = useState(false);

  const { t } = useTranslation();
  const { direction } = useContext(AppContext);

  return (
    <>
      <button
        className={`${styles.toggleBtn} ${direction === "rtl" ? styles.rtl : styles.ltr}`}
        onClick={() => setOpen(!open)}
        style={{
          [direction === "rtl" ? "right" : "left"]: 15,
          left: direction === "rtl" ? "auto" : 15,
          right: direction === "ltr" ? "auto" : 15,
        }}
      >
        <i className="bi bi-list" style={{ color: "white" }}></i>
      </button>

      <div className={`${styles.sidebar} ${direction === "rtl" ? styles.rtl : styles.ltr} ${open ? styles.open : ""}`}>
        <div className={styles.logo}>
          <img src={logo} alt="" style={{ height: "70px", width: "100%" }} />
        </div>

        <div className={styles.menu}>
          <div className={`mt-3 ${direction === "rtl" ? styles.itemRtl : styles.itemLtr}`}>
            <i className="bi bi-person-circle"></i>
            <span>{t("sidebar.admin")}</span>
          </div>

          <div className={`mt-3 ${direction === "rtl" ? styles.itemRtl : styles.itemLtr}`}>
         <Link to={'/'} className={`${direction === "rtl" ? styles.itemRtl : styles.itemLtr}`}>  <i className="bi bi-globe2"></i>
            <span>{t("sidebar.main")}</span> </Link> 
          </div>

          {/* <div className={`mt-3 ${direction === "rtl" ? styles.itemRtl : styles.itemLtr}`}>
            <i className="bi bi-people"></i>
            <span>{t("sidebar.customers")}</span>
          </div> */}

          {/* التقارير */}
          {/* <div
            className={`mt-3 ${direction === "rtl" ? styles.itemRtl : styles.itemLtr}`}
            onClick={() => setReportsOpen(!reportsOpen)}
          >
            <i className="bi bi-bar-chart-steps"></i>
            <span>{t("sidebar.reports")}</span>
            <i className={`bi ${reportsOpen ? "bi-caret-up-fill" : "bi-caret-down-fill"}`} />
          </div> */}
          {/* {reportsOpen && (
            <div className={styles.subMenu}>
              <div>{t("sidebar.salesReport")}</div>
              <div>{t("sidebar.expensesReport")}</div>
              <div>{t("sidebar.performanceReport")}</div>
            </div>
          )} */}

          {/* العمليات */}
          <div
            className={`mt-3 ${direction === "rtl" ? styles.itemRtl : styles.itemLtr}`}
            onClick={() => setOperationsOpen(!operationsOpen)}
          >
            <i className="bi bi-clipboard2-pulse"></i>
            <span>{t("sidebar.operations")}</span>
            <i className={`bi ${operationsOpen ? "bi-caret-up-fill" : "bi-caret-down-fill"}`} />
          </div>
          {operationsOpen && (
            <div className={`${styles.subMenu} ${direction === "rtl" ? styles.subMenuRtl : styles.subMenuLtr}`}>
              <div><Link to={'/DownloadBenefits'}>{t("sidebar.downloadBenefit")}</Link></div>
              <div>{t("sidebar.Benefitfrom")}</div>
            </div>
          )}

          {/* الإدارة */}
          <div
            className={`mt-3 ${direction === "rtl" ? styles.itemRtl : styles.itemLtr}`}
            onClick={() => setManagementOpen(!managementOpen)}
          >
            <i className="bi bi-file-earmark-bar-graph"></i>
            <span>{t("sidebar.management")}</span>
            <i className={`bi ${managementOpen ? "bi-caret-up-fill" : "bi-caret-down-fill"}`} />
          </div>
          {managementOpen && (
            <div className={`${styles.subMenu} ${direction === "rtl" ? styles.subMenuRtl : styles.subMenuLtr}`} >
               <div><Link to={'/register'}>{t("sidebar.users")}</Link></div>
               <div><Link to={'/Categories'}>{t("sidebar.catgories")}</Link></div>
              <div><Link to={"/Campaign"}>{t("sidebar.campines")}</Link></div>
              <div><Link to={"/path"}>{t("sidebar.paths")}</Link></div>
            </div>
          )}
        </div>
      </div>

      {open && <div className={styles.overlay} onClick={() => setOpen(false)} />}
    </>
  );
}
