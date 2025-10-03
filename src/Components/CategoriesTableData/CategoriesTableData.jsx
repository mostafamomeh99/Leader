import React, { useState, useEffect } from "react";
import styles from "./CategoriesTableData.module.css";
import { useTranslation } from "react-i18next";
import CategoriesFilterTable from "../../Components/CategoriesFilterTable/CategoriesFilterTable";
import { Link } from "react-router-dom";
import { Api_URL } from "../../Resources/ApiUrl";
import { toast } from "react-toastify";

const CategoriesTableData = () => {
  const { t } = useTranslation();
  const [filters, setFilters] = useState({ name: "", path: "" });
  const [data, setData] = useState([]);
   const [pagination, setPagination] = useState({
      pageIndex: 1,
      pageSize: 5,
      totalPages: 0,
      totalItems: 0,
    });
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);
  const rowsPerPage = 5;


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
  const fetchData = async (filters, page) => {
    try {
      const body = {
        displayName: filters.name || "",
        categoryPathName: filters.path || "",
        pageIndex: page,
        pageSize: rowsPerPage,
      };

      const res = await fetch(`${Api_URL}/CP/v1.0/Category/GetByFilter`, {
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
    fetchData(filters, currentPage);
  }, [filters, currentPage]);

  const handleSearch = (newFilters) => {
    setFilters(newFilters);
    setCurrentPage(1);
  };

  return (
    <div className="container mt-4">
      <CategoriesFilterTable onSearch={handleSearch} />

      <div className="table-responsive">
        <table className={`table table-bordered ${styles.customTable}`}>
          <thead className={styles.tableHead}>
            <tr>
              <th>{t("tableCategoryHeaders.category")}</th>
              <th>{t("tableCategoryHeaders.categoryPath")}</th>
              <th>{t("tableCategoryHeaders.actions")}</th>
            </tr>
          </thead>
          <tbody>
            {data.length > 0 ? (
              data.map((item, index) => (
                <tr key={index}>
                  <td>{item.displayName}</td>
                  <td>{item.categoryPathName || `${t("tableCategoryHeaders.noPath")}`}</td>
                  <td>
                    <Link to={`/NewCategory/${item.id}`}>
                      <button className={styles.buttonCall}>
                        <i
                          className={`bi bi-pencil-square fs-1 ${styles.iconCall}`}
                        ></i>
                      </button>
                    </Link>
                  </td>
                </tr>
              ))
            ) : (
              <tr>
                <td colSpan="3" className="text-center">
                  {t("common.noData")}
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
        </div> */}
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

export default CategoriesTableData;
