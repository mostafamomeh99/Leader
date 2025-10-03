
//front-end search 
import React, { useState } from "react";
import { useTranslation } from "react-i18next";
import { Link } from "react-router-dom";
import { toast } from "react-toastify";

const CampaignFilterTable = ({ onSearch }) => {
  const { t } = useTranslation();
  const [formData, setFormData] = useState({
    name: "",
    priority: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSearch = () => {
    if (!formData.name && !formData.priority) {
      toast.error(
        t("errors.atLeastOneFilter") || 
        "Please enter at least one filter value", 
        {
          position: "top-right",
          style: { backgroundColor: "red", color: "white" },
        }
      );
      return;
    }
    onSearch(formData);
  };

  const handleReset = () => {
    const emptyFilters = { name: "", priority: "" };
    setFormData(emptyFilters);
    onSearch(emptyFilters);
  };

  return (
    <div className="row mb-3 align-items-end">
      <div className="col-12 col-md-3 mb-2">
        <input
          type="text"
          name="name"
          placeholder={t("tableCampainHeaders.campaign")}
          className="form-control"
          value={formData.name}
          onChange={handleChange}
        />
      </div>
      <div className="col-12 col-md-3 mb-2">
        <input
          type="text"
          name="priority"
          placeholder={t("tableCampainHeaders.priority")}
          className="form-control"
          value={formData.priority}
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
        <Link to={"/NewCampaign"}>
          <button
            className="btn btn-primary"
            style={{ fontSize: "16px", fontWeight: "700", width: "300px" }}
          >
            + {t("tableCampainHeaders.addCampaign")}
          </button>
        </Link>
      </div>
    </div>
  );
};

export default CampaignFilterTable;
