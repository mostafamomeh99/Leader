// old static 

// import React, { useState } from "react";
// import styles from "./UsersTableData.module.css";
// import { useTranslation } from "react-i18next";
// import UsersFilterTable from "../UsersFilterTable/UsersFilterTable"
// import { Link } from "react-router-dom";
// const UsersTableData = () => {
//   const { t } = useTranslation();

//   // بيانات تجريبية
// const data = [
//   {
//     empName: "أحمد علي",
//     phone: "01012345678",
//     empId: "EMP001",
//     extension: "1234",
//     username: "ahmed.ali",
//     email: "ahmed@example.com",
//     team: "فريق الدعم",
//     role: "موظف خدمة عملاء",
//     status: "نشط",
//   },
//   {
//     empName: "منى محمد",
//     phone: "01098765432",
//     empId: "EMP002",
//     extension: "5678",
//     username: "mona.mohamed",
//     email: "mona@example.com",
//     team: "المبيعات",
//     role: "مشرفة",
//     status: "غير نشط",
//   },
// ];

//   //pagination 
//   const [currentPage, setCurrentPage] = useState(1);
//   const rowsPerPage = 5; 

  
//   const indexOfLastRow = currentPage * rowsPerPage;
//   const indexOfFirstRow = indexOfLastRow - rowsPerPage;
//   const currentRows = data.slice(indexOfFirstRow, indexOfLastRow);

  
//   const totalPages = Math.ceil(data.length / rowsPerPage);

// // filter
//  const [filters, setFilters] = useState({
//     phone: "",
//     id: "",
//     name: "",
//     category: "",
//     campaign: "",
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
//           <UsersFilterTable
//  onSearch={handleSearch} 
//       />



//       <div className="table-responsive">
//         <table className={`table table-bordered ${styles.customTable}`}>
//           <thead className={styles.tableHead}>
//             <tr>
//              <th>{t("tableUserHeaders.empName")}</th>
//     <th>{t("tableUserHeaders.phone")}</th>
//     <th>{t("tableUserHeaders.empId")}</th>
//     <th>{t("tableUserHeaders.extension")}</th>
//     <th>{t("tableUserHeaders.username")}</th>
//     <th>{t("tableUserHeaders.email")}</th>
//     <th>{t("tableUserHeaders.team")}</th>
//     <th>{t("tableUserHeaders.role")}</th>
//     <th>{t("tableUserHeaders.status")}</th>
//     <th>{t("tableUserHeaders.actions")}</th>
//             </tr>
//           </thead>
//           <tbody>
//             {currentRows.map((item, index) => (
//               <tr key={index}>
//                 <td>{item.empName}</td>
//       <td>{item.phone}</td>
//       <td>{item.empId}</td>
//       <td>{item.extension}</td>
//       <td>{item.username}</td>
//       <td>{item.email}</td>
//       <td>{item.team}</td>
//       <td>{item.role}</td>
//       <td>{item.status}</td>
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

// export default UsersTableData;

// new backend

import React, { useState, useEffect } from "react";
import styles from "./UsersTableData.module.css";
import { useTranslation } from "react-i18next";
import UsersFilterTable from "../UsersFilterTable/UsersFilterTable";
import { Link } from "react-router-dom";
import { Api_URL } from "../../Resources/ApiUrl";

const UsersTableData = () => {
  const { t } = useTranslation();

  // الـ state بتاع الداتا
  const [data, setData] = useState([]);
  const [totalPages, setTotalPages] = useState(0);
  const [currentPage, setCurrentPage] = useState(1);
  const [pagination, setPagination] = useState({
    pageIndex: 1,
    pageSize: 5,
    totalPages: 0,
    totalItems: 0,
  });
  const rowsPerPage = 5; // ممكن تخليها dynamic من السيرفر

  // فلترز
  const [filters, setFilters] = useState({
    name: "",
    phone: "",
    email: "",
    username: "",
    empId: "",
    extension: "",
    team: "",
  });

  // دالة لطلب الداتا من الـ API
  const fetchData = async (pageIndex = 1, pageSize = rowsPerPage, appliedFilters = {}) => {
    const body = {
      pageIndex,
      pageSize,
      fullName: appliedFilters.name || "",
      phoneNumber: appliedFilters.phone || "",
      email: appliedFilters.email || "",
      userName: appliedFilters.username || "",
      employeeNumber: appliedFilters.empId || "",
      extension: appliedFilters.extension || "",
      // teamId: appliedFilters.team || null, // لو رجعت TeamId من السيرفر
    };

    try {
      const res = await fetch(`${Api_URL}/CP/v1.0/User/GetUser`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(body),
      });

      const result = await res.json();

      if (result.succeeded) {
        setData(result.data.items || []);
            setPagination({
        pageIndex: result.data.pageIndex,
        pageSize: result.data.pageSize,
        totalPages: result.data.totalPages,
        totalItems: result.data.totalItems,
      });
      }
    } catch (error) {
      console.error("Fetch error:", error);
    }
  };


    const getPaginationRange = (current, total) => {
  const delta = 2; // عدد الصفحات اللي تظهر قبل/بعد الحالية
  const range = [];
  const rangeWithDots = [];
  let l;

  for (let i = 1; i <= total; i++) {
    if (i === 1 || i === total || (i >= current - delta && i <= current + delta)) {
      range.push(i);
    }
  }

  for (let i of range) {
    if (l) {
      if (i - l === 2) {
        rangeWithDots.push(l + 1);
      } else if (i - l !== 1) {
        rangeWithDots.push("...");
      }
    }
    rangeWithDots.push(i);
    l = i;
  }

  return rangeWithDots;
};

const handlePageChange = (newPage) => {
  if (newPage >= 1 && newPage <= pagination.totalPages) {
    setCurrentPage(newPage);
    fetchData(newPage, rowsPerPage, filters);
  }
};
  // أول ما الصفحة تفتح يجيب داتا
  useEffect(() => {
    fetchData(currentPage, rowsPerPage, filters);
  }, [currentPage]);

  // دالة البحث
  const handleSearch = (appliedFilters) => {
    setFilters(appliedFilters);
    setCurrentPage(1); // رجع للصفحة الأولى
    fetchData(1, rowsPerPage, appliedFilters);
  };

  return (
    <div className="container mt-4">
      <UsersFilterTable onSearch={handleSearch} />

      <div className="table-responsive">
        <table className={`table table-bordered ${styles.customTable}`}>
          <thead className={styles.tableHead}>
            <tr>
              <th>{t("tableUserHeaders.empName")}</th>
              <th>{t("tableUserHeaders.phone")}</th>
              <th>{t("tableUserHeaders.empId")}</th>
              <th>{t("tableUserHeaders.extension")}</th>
              <th>{t("tableUserHeaders.username")}</th>
              <th>{t("tableUserHeaders.email")}</th>
              <th>{t("tableUserHeaders.team")}</th>
              <th>{t("tableUserHeaders.role")}</th>
              <th>{t("tableUserHeaders.status")}</th>
              <th>{t("tableUserHeaders.actions")}</th>
            </tr>
          </thead>
  <tbody>
  {data.length > 0 ? (
    data.map((item, index) => (
      <tr key={index}>
        <td>{item.fullName || t("common.noDataYet")}</td>
        <td>{item.phoneNumber || t("common.noDataYet")}</td>
        <td>{item.employeeNumber || t("common.noDataYet")}</td>
        <td>{item.extension || t("common.noDataYet")}</td>
        <td>{item.userName || t("common.noDataYet")}</td>
        <td>{item.email || t("common.noDataYet")}</td>
        <td>{item.teamName || t("common.noDataYet")}</td>
        <td>{item.roleName || t("common.noDataYet")}</td>
        <td>
          {item.isStillEmployee === null || item.isStillEmployee === undefined
            ? t("common.noDataYet")
            : item.isStillEmployee
            ? t("active") // نشط
            : t("inactive")} {/* غير نشط */}
        </td>
        <td>
          <Link to={`/newRegister/${item.id}`}>
            <button className={`${styles.buttonCall}`}>
              <i className={`bi bi-pencil-square fs-1 ${styles.iconCall}`}></i>
            </button>
          </Link>
        </td>
      </tr>
    ))
  ) : (
    <tr>
      <td colSpan="10" className="text-center">
        {t("noData")}
      </td>
    </tr>
  )}
</tbody>

        </table>

        {/* Pagination */}
        {/* <div className="d-flex justify-content-center mt-3">
          <nav>
            <ul className="pagination">
              <li className={`page-item ${currentPage === 1 ? "disabled" : ""}`}>
                <button className="page-link" onClick={() => setCurrentPage(currentPage - 1)}>
                  {t("pervious")}
                </button>
              </li>
              {Array.from({ length: totalPages }, (_, i) => (
                <li
                  key={i}
                  className={`page-item ${currentPage === i + 1 ? "active" : ""}`}
                >
                  <button className="page-link" onClick={() => setCurrentPage(i + 1)}>
                    {i + 1}
                  </button>
                </li>
              ))}
              <li className={`page-item ${currentPage === totalPages ? "disabled" : ""}`}>
                <button className="page-link" onClick={() => setCurrentPage(currentPage + 1)}>
                  {t("next")}
                </button>
              </li>
            </ul>
          </nav>
        </div> */}
              {/* <nav className="mt-3">
        <ul className="pagination justify-content-center">
          <li className={`page-item ${pagination.pageIndex === 1 ? "disabled" : ""}`}>
            <button
              className="page-link"
              onClick={() => handlePageChange(pagination.pageIndex - 1)}
            >
              {t("pervious")}
            </button>
          </li>

        {getPaginationRange(pagination.pageIndex, pagination.totalPages).map((page, idx) => (
  <li
    key={idx}
    className={`page-item ${page === pagination.pageIndex ? "active" : ""} ${page === "..." ? "disabled" : ""}`}
  >
    {page === "..." ? (
      <span className="page-link">...</span>
    ) : (
      <button className="page-link" onClick={() => handlePageChange(page)}>
        {page}
      </button>
    )}
  </li>
))}

          <li
            className={`page-item ${
              pagination.pageIndex === pagination.totalPages ? "disabled" : ""
            }`}
          >
            <button
              className="page-link"
              onClick={() => handlePageChange(pagination.pageIndex + 1)}
            >
              {t("next")}
            </button>
          </li>
        </ul>
      </nav> */}

      <nav className="mt-3">
  <ul className="pagination justify-content-center">
    <li className={`page-item ${pagination.pageIndex === 1 ? "disabled" : ""}`}>
      <button
        className="page-link"
        onClick={() => handlePageChange(pagination.pageIndex - 1)}
      >
        {t("pervious")}
      </button>
    </li>

    {getPaginationRange(pagination.pageIndex, pagination.totalPages).map((page, idx) => (
      <li
        key={idx}
        className={`page-item ${page === pagination.pageIndex ? "active" : ""} ${page === "..." ? "disabled" : ""}`}
      >
        {page === "..." ? (
          <span className="page-link">...</span>
        ) : (
          <button className="page-link" onClick={() => handlePageChange(page)}>
            {page}
          </button>
        )}
      </li>
    ))}

    <li
      className={`page-item ${
        pagination.pageIndex === pagination.totalPages ? "disabled" : ""
      }`}
    >
      <button
        className="page-link"
        onClick={() => handlePageChange(pagination.pageIndex + 1)}
      >
        {t("next")}
      </button>
    </li>
  </ul>
</nav>

      </div>
    </div>
  );
};

export default UsersTableData;
