
import React, { useState } from "react";
import styles from "./PathTableData.module.css";
import { useTranslation } from "react-i18next";
import PathFilterTable from '../PathFilterTable/PathFilterTable'
import { Link } from "react-router-dom";
const PathTableData = () => {
  const { t } = useTranslation();

  // بيانات تجريبية
const data = [
    {
      pathName: "حملة رمضان",
      categoryName:"حملة رمضان",
    },
    {
      pathName: "حملة الصيف",
      categoryName: "حملة الصيف",
    },
  ];

  //pagination 
  const [currentPage, setCurrentPage] = useState(1);
  const rowsPerPage = 5; 

  
  const indexOfLastRow = currentPage * rowsPerPage;
  const indexOfFirstRow = indexOfLastRow - rowsPerPage;
  const currentRows = data.slice(indexOfFirstRow, indexOfLastRow);

  
  const totalPages = Math.ceil(data.length / rowsPerPage);

// filter
 const [filters, setFilters] = useState({
      pathName: "",
      categoryName:"",
  });



  const handleSearch = async (filters) => {
    //ـ API Call
    // مثال:
    // try {
    //   const params = new URLSearchParams(filters).toString();
    //   const response = await fetch(`/api/data?${params}`);
    //   const data = await response.json();
    //   setTableData(data);
    // } catch (error) {
    //   console.error(error);
    // }
  };


  return (
    <div className="container mt-4">
          <PathFilterTable
 onSearch={handleSearch} 
      />



      <div className="table-responsive">
        <table className={`table table-bordered ${styles.customTable}`}>
          <thead className={styles.tableHead}>
            <tr>
<th>{t("tablePathHeaders.pathName")}</th>
<th>{t("tablePathHeaders.categoryName")}</th>
<th>{t("tablePathHeaders.actions")}</th>
            </tr>
          </thead>
          <tbody>
            {currentRows.map((item, index) => (
              <tr key={index}>
      <td>{item.pathName}</td>
      <td>{item.categoryName}</td>
                <td>
                  <Link to={'/Editpath'}>
                  <button className={`${styles.buttonCall}`}>
                    <i className={`bi bi-pencil-square fs-1 ${styles.iconCall}`}></i>
                  </button>
                  </Link>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      
        <div className="d-flex justify-content-center mt-3">
          <nav>
            <ul className="pagination">
              <li className={`page-item ${currentPage === 1 ? "disabled" : ""}`}>
                <button className="page-link" onClick={() => setCurrentPage(currentPage - 1)}>
                 {t('pervious')}
                </button>
              </li>
              {Array.from({ length: totalPages }, (_, i) => (
                <li key={i} className={`page-item ${currentPage === i + 1 ? "active" : ""}`}>
                  <button className="page-link" onClick={() => setCurrentPage(i + 1)}>
                    {i + 1}
                  </button>
                </li>
              ))}
              <li className={`page-item ${currentPage === totalPages ? "disabled" : ""}`}>
                <button className="page-link" onClick={() => setCurrentPage(currentPage + 1)}>
                  {t('next')}
                </button>
              </li>
            </ul>
          </nav>
        </div>
      </div>
    </div>
  );
};

export default PathTableData;
