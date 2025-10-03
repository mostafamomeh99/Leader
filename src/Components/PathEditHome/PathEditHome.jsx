import React, { useState } from "react";
import { useTranslation } from "react-i18next";

const PathEditHome = () => {
  const { t } = useTranslation();
  const [formData, setFormData] = useState({
    categoryNameAr: "",
    categoryNameEn: "",
    categoryPath: "",
    campainPerdictive:""
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log("New Category Data:", formData);
  };

  return (
    <div className="container mt-4 p-4 shadow-lg rounded bg-white" >
      <h4 className="mb-3">{t("path.pathInfo")}</h4>
      <form onSubmit={handleSubmit} className="row g-3">
        
        {/* الاسم بالعربية */}
        <div className="col-md-6">
          <label className="form-label">{t("Category.nameAr")} </label>
          <input
            type="text"
            className="form-control"
            name="categoryNameAr"
            value={formData.categoryNameAr}
            onChange={handleChange}
            required
          />
        </div>

        {/* الاسم بالإنجليزية */}
        <div className="col-md-6">
          <label className="form-label">{t("Category.nameEn")} </label>
          <input
            type="text"
            className="form-control"
            name="categoryNameEn"
            value={formData.categoryNameEn}
            onChange={handleChange}
            required
          />
        </div>


{/* الحقل الذى يعبر عن حالة المكالمة */}
<div className="col-md-6">
  <label className="form-label">{t("path.callStatusField")}</label>
  <select
    className="form-select"
    name="callStatusField"
    value={formData.callStatusField || ""}
    onChange={handleChange}
    required
  >
    <option value="">{t("common.choose")}</option>
    <option value="status1">مكالمه ناجحه / Successful Call</option>
    <option value="status2">مكالمه فاشله / Failed Call</option>
    <option value="status3">مكالمه قيد التنفيذ / In Progress</option>
  </select>
</div>

{/* الحقل الذى يعبر عن الصفحة الرئيسية */}
<div className="col-md-6">
  <label className="form-label">{t("path.homeField")}</label>
  <select
    className="form-select"
    name="homeField"
    value={formData.homeField || ""}
    onChange={handleChange}
    required
  >
    <option value="">{t("common.choose")}</option>
    <option value="main1">الرئيسية 1 / Main Page 1</option>
    <option value="main2">الرئيسية 2 / Main Page 2</option>
    <option value="main3">الرئيسية 3 / Main Page 3</option>
  </select>
</div>


        <div className="col-12 d-flex justify-content-center mt-5">
          <button type="submit" className="btn" style={{backgroundColor:"#163a90",color:"white",width:"200px",}}>
            {t("common.submit")}
          </button>
        </div>
      </form>
    </div>
  );
};

export default PathEditHome;
