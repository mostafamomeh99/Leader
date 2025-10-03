
import React, { useState } from "react";
import { useTranslation } from "react-i18next";
import {Link} from 'react-router-dom'
const PathFilterTable = ({ onSearch }) => {
      const { t } = useTranslation();
    const [formData, setFormData] = useState({
    pathName: "",
    categoryName: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSearch = () => {
    onSearch(formData); // API
  };

  const handleReset = () => {
    const emptyFilters = {
    pathName: "",
    categoryName: "",
    };
    setFormData(emptyFilters);
    onSearch(emptyFilters); //API
  };

  return (<>
    <div className="row mb-3 align-items-end">
      <div className="col-12 col-md-3 mb-2">
        <input
          type="text"
          name="pathName"
          placeholder={t("tablePathHeaders.pathName")}
          className="form-control"
          value={formData.pathName}
          onChange={handleChange}
        />
      </div>
      <div className="col-12 col-md-3 mb-2">
        <input
          type="text"
          name="categoryName"
          placeholder={t("tableCategoryHeaders.category")}
          className="form-control"
          value={formData.categoryName}
          onChange={handleChange}
        />
      </div>



      <div className="col-12 col-md-1 mb-2">
        <button className="btn btn-primary w-100" onClick={handleSearch}>
          <i className="bi bi-search"></i>
        </button>
      </div>
      <div className="col-12 col-md-1 mb-2">
        <button className="btn btn-danger w-100" onClick={handleReset}>
           {t("resetSearch")}
        </button>
      </div>

      
        <div className="col-4 col-md-1 mb-2">
          <Link to={'/addpath'}>
          <button
            className="btn btn-primary "
            style={{fontSize:"16px",fontWeight:"700",width:"300px"}}
    
          >
           + {t("path.addPath")}
          </button>
          </Link>
        </div>
    </div>


</>
  );
};

export default PathFilterTable;
