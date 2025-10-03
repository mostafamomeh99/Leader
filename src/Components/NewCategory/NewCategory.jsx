
import React, { useState, useEffect } from "react";
import { useTranslation } from "react-i18next";
import { Api_URL } from "../../Resources/ApiUrl";
import { toast } from "react-toastify";
import { useParams } from "react-router-dom";

const NewCategory = () => {
  const { t } = useTranslation();
  const { categoryId } = useParams(); 
  const [isEditMode, setIsEditMode] = useState(false);

  const [formData, setFormData] = useState({
    NameAr: "",
    NameEn: "",
    CategoryPathId: "",
    AVAYAAURACampaignPredictiveId: "",
    UserIds:[]
  });

  const [errors, setErrors] = useState({});
  const regexAr = /[a-zA-Z\u0600-\u06FF]{3,}/;
  const regexEn = /[a-zA-Z]{3,}/;


  useEffect(() => {
    if (categoryId) {
      setIsEditMode(true);
      const fetchData = async () => {
        try {
          const res = await fetch(`${Api_URL}/CP/v1.0/Category/GetById`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(categoryId),
          });

          if (res.ok) {
            const data = await res.json();
            const category = data.data || {};
            setFormData({
              NameAr: category.nameAr || "",
              NameEn: category.nameEn || "",
              CategoryPathId: category.categoryPathId || "",
              AVAYAAURACampaignPredictiveId:
                category.avayaauraCampaignPredictiveId || null,
                 UserIds:[]
            });
          } else {
            toast.error(t("common.failedOperation"), {
              position: "top-right",
              style: { backgroundColor: "red", color: "white" },
            });
          }
        } catch (err) {
          toast.error(t("common.failedOperation"), {
            position: "top-right",
            style: { backgroundColor: "red", color: "white" },
          });
        }
      };

      fetchData();
    }
  }, [categoryId]);

  // validation
  const validate = () => {
    let newErrors = {};
    let isValid = true;

    if (!regexAr.test(formData.NameAr)) {
      newErrors.NameAr = t("errors.fullNameArInvalid");
      isValid = false;
    }
    if (!regexEn.test(formData.NameEn)) {
      newErrors.NameEn = t("errors.fullNameEn");
      isValid = false;
    }

    setErrors(newErrors);
    return isValid;
  };

  // handleChange
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  // handleSubmit
  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!validate()) return;

    try {
      const url = isEditMode
        ? `${Api_URL}/CP/v1.0/Category/Edit`
        : `${Api_URL}/CP/v1.0/Category/New`;

 const bodyData = {
      ...(isEditMode ? { Id: categoryId } : {}),
      ...formData,
      CategoryPathId: formData.CategoryPathId || null,
      AVAYAAURACampaignPredictiveId: formData.AVAYAAURACampaignPredictiveId || null,
      UserIds: formData.UserIds?.length ? formData.UserIds : [],
    };
    
      const res = await fetch(url, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(bodyData),
      });

      if (res.ok) {
        toast.success(t("common.successOperation"), {
          position: "top-right",
          style: { backgroundColor: "green", color: "white" },
        });
      } else {
        const errorData = await res.json();
        toast.error(errorData.message || t("common.failedOperation"), {
          position: "top-right",
          style: {
            backgroundColor: "red",
            color: "white",
            whiteSpace: "pre-line",
          },
        });
      }
    } catch (err) {
      toast.error(t("common.failedOperation"), {
        position: "top-right",
        style: { backgroundColor: "red", color: "white" },
      });
    }
  };

  return (
    <div className="container mt-4 p-4 shadow-lg rounded bg-white">
      <h4 className="mb-3">{t("Category.data")}</h4>
      <form onSubmit={handleSubmit} className="row g-3">
        {/* الاسم بالعربية */}
        <div className="col-md-6">
          <label className="form-label">{t("Category.nameAr")}</label>
          <input
            type="text"
            className={`form-control ${errors.NameAr ? "is-invalid" : ""}`}
            name="NameAr"
            value={formData.NameAr}
            onChange={handleChange}
          />
          {errors.NameAr && (
            <div className="invalid-feedback">{errors.NameAr}</div>
          )}
        </div>

        {/* الاسم بالإنجليزية */}
        <div className="col-md-6">
          <label className="form-label">{t("Category.nameEn")}</label>
          <input
            type="text"
            className={`form-control ${errors.NameEn ? "is-invalid" : ""}`}
            name="NameEn"
            value={formData.NameEn}
            onChange={handleChange}
          />
          {errors.NameEn && (
            <div className="invalid-feedback">{errors.NameEn}</div>
          )}
        </div>

        {/* مسار التصنيف */}
        <div className="col-md-6">
          <label className="form-label">{t("Category.pathName")}</label>
          <select
            className="form-select"
            name="CategoryPathId"
            value={formData.CategoryPathId}
            onChange={handleChange}
          >
            <option value="">{t("operations.chooseCategory")}</option>
            {/* CategoryPath */}
            <option value="04A44C19-B2B4-4C40-BA93-1DC92F904BE3">Path 1</option>
            <option value="EB890DDB-3EB1-4752-B8A5-91C77EE3BA88">Path 2</option>
          </select>
        </div>

        {/* الحملة Predictive */}
        <div className="col-md-6">
          <label className="form-label">
            {t("Category.campainPerdictive")}
          </label>
          <select
            className="form-select"
            name="AVAYAAURACampaignPredictiveId"
            value={formData.AVAYAAURACampaignPredictiveId}
            onChange={handleChange}
          >
            <option value="">{t("operations.chooseCampaign")}</option>
     
            <option value="33333333-3333-3333-3333-333333333333">Campaign 1</option>
            <option value="44444444-4444-4444-4444-444444444444">Campaign 2</option>
          </select>
        </div>

        <div className="col-12 d-flex justify-content-center mt-5">
          <button
            type="submit"
            className="btn"
            style={{
              backgroundColor: "#163a90",
              color: "white",
              width: "200px",
            }}
          >
            {isEditMode ? t("common.update") : t("common.submit")}
          </button>
        </div>
      </form>
    </div>
  );
};

export default NewCategory;
