
import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { Api_URL } from "../../Resources/ApiUrl";
import styles from "./TableData.module.css";
import { useTranslation } from "react-i18next";

function TableData({ filters }) {
  const { t } = useTranslation();

  // State للداتا و الفلاتر و الصفحات
  const [tableData, setTableData] = useState([]);
  const [pagination, setPagination] = useState({
    pageIndex: 1,
    pageSize: 5,
    totalPages: 0,
    totalItems: 0,
  });
  const [loading, setLoading] = useState(false);

  // 🔹 جلب البيانات من الـ API
  const fetchTableData = async (page = 1, appliedFilters = {}) => {
    try {
      setLoading(true);

      const response = await fetch(`${Api_URL}/CP/v1.0/ScheduledCall/GetByFilter`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          pageIndex: page,
          pageSize: pagination.pageSize,
          ...appliedFilters,
        }),
      });

      if (!response.ok) {
        console.error("API error:", response.status, response.statusText);
        setLoading(false);
        return;
      }

      const result = await response.json();
      if (result?.succeeded && result?.data) {
        setTableData(result.data.items);
        setPagination({
          pageIndex: result.data.pageIndex,
          pageSize: result.data.pageSize,
          totalPages: result.data.totalPages,
          totalItems: result.data.totalItems,
        });
      }
    } catch (error) {
      console.error("Error fetching table data:", error);
    } finally {
      setLoading(false);
    }
  };


  const getPaginationRange = (current, total) => {
    const delta = 2;
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


  // 🔹 أول مرة يفتح الجدول
  useEffect(() => {
    fetchTableData(1, filters);
  }, [filters]);

  // 🔹 تغيير الصفحة
  const handlePageChange = (newPage) => {
    fetchTableData(newPage, filters);
  };



  return (
       <div className="container mt-4">

      {/* Table */}
      <div className="table-responsive">
       <table className={`table table-bordered ${styles.customTable}`}>
    <thead className={styles.tableHead}>
            <tr>
              <th>{t("tableHeaders.nationalId")}</th>
             <th>{t("tableHeaders.phone")}</th>
             <th>{t("tableHeaders.name")}</th>
             <th>{t("tableHeaders.campaign")}</th>
              <th>{t("tableHeaders.category")}</th>
             <th>{t("tableHeaders.priority")}</th>       
             <th>{t("tableHeaders.lastStatus")}</th>
             <th>{t("tableHeaders.actions")}</th>
            </tr>
          </thead>
          <tbody>
            {loading ? (
              <tr>
                <td colSpan="8" className="text-center">
                  {t("loading")}...
                </td>
              </tr>
            ) : tableData.length > 0 ? (
              tableData.map((item) => (
                <tr key={item.id}>
                  <td>{item.idNumber}</td>
                  <td>{item.mobile}</td>
                  <td>{item.name}</td>
                  <td>{item.campaign}</td>
                  <td>{item.category}</td>
                  <td>{item.priority}</td>
                  <td>{item.previousCallStatus}</td>
                  <td>
                    <Link to="/calls">
                      <button className={styles.buttonCall}>
                        <i className={`bi bi-telephone-fill fs-1 ${styles.iconCall}`}></i>
                      </button>
                    </Link>
                  </td>
                </tr>
              ))
            ) : (
              <tr>
                <td colSpan="8" className="text-center">
                  {t("noData")}
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>

      {/* Pagination */}
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
                className={`page-item ${page === pagination.pageIndex ? "active" : ""} ${
                  page === "..." ? "disabled" : ""
                }`}
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
  );
}

export default TableData;
