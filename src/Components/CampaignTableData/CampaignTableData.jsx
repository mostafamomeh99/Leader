
// import React, { useState } from "react";
// import styles from "./CampaignTableData.module.css";
// import { useTranslation } from "react-i18next";
// import CampaignFilterTable from '../CampaignFilterTable/CampaignFilterTable'
// import { Link } from "react-router-dom";
// const CampaignTableData = () => {
//   const { t } = useTranslation();

//   // بيانات تجريبية
// const data = [
//     {
//       campaign: "حملة رمضان",
//       priority: "عالية"
//     },
//     {
//       campaign: "حملة الصيف",
//       priority: "متوسطة"
//     },
//   ];

//   //pagination 
//   const [currentPage, setCurrentPage] = useState(1);
//   const rowsPerPage = 5; 

  
//   const indexOfLastRow = currentPage * rowsPerPage;
//   const indexOfFirstRow = indexOfLastRow - rowsPerPage;
//   const currentRows = data.slice(indexOfFirstRow, indexOfLastRow);

  
//   const totalPages = Math.ceil(data.length / rowsPerPage);

// // filter
//  const [filters, setFilters] = useState({
//     category: "",
//     categoryPath: "",
//   });



//   const handleSearch = async (filters) => {
//     //ـ API Call
//     // مثال:
//     // try {
//     //   const params = new URLSearchParams(filters).toString();
//     //   const response = await fetch(`/api/data?${params}`);
//     //   const data = await response.json();
//     //   setTableData(data);
//     // } catch (error) {
//     //   console.error(error);
//     // }
//   };


//   return (
//     <div className="container mt-4">
//           <CampaignFilterTable
//  onSearch={handleSearch} 
//       />



//       <div className="table-responsive">
//         <table className={`table table-bordered ${styles.customTable}`}>
//           <thead className={styles.tableHead}>
//             <tr>
// <th>{t("tableCampainHeaders.campaign")}</th>
// <th>{t("tableCampainHeaders.priority")}</th>
// <th>{t("tableCampainHeaders.actions")}</th>
//             </tr>
//           </thead>
//           <tbody>
//             {currentRows.map((item, index) => (
//               <tr key={index}>
//       <td>{item.campaign}</td>
//       <td>{item.priority}</td>
//                 <td>
//                   <Link to={'/calls'}>
//                   <button className={`${styles.buttonCall}`}>
//                     <i className={`bi bi-pencil-square fs-1 ${styles.iconCall}`}></i>
//                   </button>
//                   </Link>
//                 </td>
//               </tr>
//             ))}
//           </tbody>
//         </table>
      
//         <div className="d-flex justify-content-center mt-3">
//           <nav>
//             <ul className="pagination">
//               <li className={`page-item ${currentPage === 1 ? "disabled" : ""}`}>
//                 <button className="page-link" onClick={() => setCurrentPage(currentPage - 1)}>
//                  {t('pervious')}
//                 </button>
//               </li>
//               {Array.from({ length: totalPages }, (_, i) => (
//                 <li key={i} className={`page-item ${currentPage === i + 1 ? "active" : ""}`}>
//                   <button className="page-link" onClick={() => setCurrentPage(i + 1)}>
//                     {i + 1}
//                   </button>
//                 </li>
//               ))}
//               <li className={`page-item ${currentPage === totalPages ? "disabled" : ""}`}>
//                 <button className="page-link" onClick={() => setCurrentPage(currentPage + 1)}>
//                   {t('next')}
//                 </button>
//               </li>
//             </ul>
//           </nav>
//         </div>
//       </div>
//     </div>
//   );
// };

// export default CampaignTableData;
import React, { useState, useEffect } from "react";
import styles from "./CampaignTableData.module.css";
import { useTranslation } from "react-i18next";
import CampaignFilterTable from "../CampaignFilterTable/CampaignFilterTable";
import { Link } from "react-router-dom";
import { Api_URL } from "../../Resources/ApiUrl";
import { toast } from "react-toastify";

const CampaignTableData = () => {
  const { t } = useTranslation();
const [filters, setFilters] = useState({ name: "", priority: "" });
  const [data, setData] = useState([]); 
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);
  const rowsPerPage = 5;

  const fetchData = async (filters, page) => {
  try {
    const body = {
      displayName: filters.name || "",
      priorityName: filters.priority || "",
      pageIndex: page,
      pageSize: rowsPerPage,
    };

    const res = await fetch(`${Api_URL}/CP/v1.0/Campaign/GetByFilter`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(body),
    });

    if (res.ok) {
      const result = await res.json();
      setData(result.data.items || []);
      setTotalPages(result.data.totalPages || 1);
    } else {
      toast.error(t("common.failedOperation"));
    }
  } catch (err) {
    toast.error(t("common.failedOperation"));
  }
};

  useEffect(() => {
  fetchData( filters,currentPage);
  }, [filters,currentPage]);

const handleSearch = (newFilters) => {
  setFilters(newFilters);   // نحدّث الفلاتر
  setCurrentPage(1);        // نرجع لأول صفحة
};

  return (
    <div className="container mt-4">
      <CampaignFilterTable onSearch={handleSearch} />

      <div className="table-responsive">
        <table className={`table table-bordered ${styles.customTable}`}>
          <thead className={styles.tableHead}>
            <tr>
              <th>{t("tableCampainHeaders.campaign")}</th>
              <th>{t("tableCampainHeaders.priority")}</th>
              <th>{t("tableCampainHeaders.actions")}</th>
            </tr>
          </thead>
          <tbody>
            {data.map((item, index) => (
              <tr key={index}>
                <td>{item.displayName}</td>
                <td>{item.priorityName || "-"}</td>
                <td>
                  <Link to={`/NewCampaign/${item.id}`}>
                    <button className={styles.buttonCall}>
                      <i className={`bi bi-pencil-square fs-1 ${styles.iconCall}`}></i>
                    </button>
                  </Link>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

         {/* Pagination */}
        <div className="d-flex justify-content-center mt-3">
          <nav>
            <ul className="pagination">
              <li className={`page-item ${currentPage === 1 ? "disabled" : ""}`}>
                <button
                  className="page-link"
                  onClick={() => setCurrentPage(currentPage - 1)}
                >
                  {t("pervious")}
                </button>
              </li>
              {Array.from({ length: totalPages }, (_, i) => (
                <li
                  key={i}
                  className={`page-item ${currentPage === i + 1 ? "active" : ""}`}
                >
                  <button
                    className="page-link"
                    onClick={() => setCurrentPage(i + 1)}
                  >
                    {i + 1}
                  </button>
                </li>
              ))}
              <li
                className={`page-item ${
                  currentPage === totalPages ? "disabled" : ""
                }`}
              >
                <button
                  className="page-link"
                  onClick={() => setCurrentPage(currentPage + 1)}
                >
                  {t("next")}
                </button>
              </li>
            </ul>
          </nav>
        </div>

      </div>
    </div>
  );
};

export default CampaignTableData;
