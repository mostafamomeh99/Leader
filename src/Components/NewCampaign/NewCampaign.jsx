import React, { useState,useEffect } from "react";
import { useTranslation } from "react-i18next";
import {Api_URL} from '../../Resources/ApiUrl';
import { toast } from "react-toastify";
import { useParams } from "react-router-dom";
const NewCampaign = () => {
  const { t } = useTranslation();
    const [formData, setFormData] = useState({
    NameAr: "",
    NameEn: "",
  });
 const { campaignId } = useParams();
  const [errors, setErrors] = useState({
    NameAr: "",
    NameEn: "",
  });
  const [isEditMode, setIsEditMode] = useState(false);
  const regexAr = /[a-zA-Z\u0600-\u06FF]{3,}/;
   const regexEn = /[a-zA-Z]{3,}/;


     useEffect(() => {
    if (campaignId) {
      setIsEditMode(true);
      const fetchData = async () => {
        try {
          const res = await fetch(`${Api_URL}/CP/v1.0/Campaign/GetById`, {
            method: "POST",
            headers: {
              "Content-Type": "application/json",
            },
         body: JSON.stringify(campaignId),
          });
console.log(res)
          if (res.ok) {
            const data = await res.json();
            console.log(data)
            console.log(data.data)
            const campaign = data.data || {  NameAr: "", NameEn: ""}; 
            setFormData({
              NameAr: campaign.nameAr || "",
              NameEn: campaign.nameEn || "",
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
  }, [campaignId]);


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
console.log(newErrors);

    setErrors(newErrors);
    return isValid;
  };

 
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

    const handleSubmit = async (e) => {
    e.preventDefault();
console.log("submitted")
    if (!validate()) return;

    try {

        const url = isEditMode
        ? `${Api_URL}/CP/v1.0/Campaign/Edit`
        : `${Api_URL}/CP/v1.0/Campaign/New`;

      const bodyData = isEditMode
        ? { Id: campaignId, ...formData } 
        : formData;

      const res = await fetch(`${url}`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(bodyData), 
      });
console.log(res.message)
      if (res.ok) {
          toast.success(t("common.successOperation"), {
        position: "top-right",
        style: { backgroundColor: "green", color: "white" },
      });
      }
else{
   const errorData = await res.json();
 toast.error(errorData.message || t("common.failedOperation"), {
        position: "top-right",
        style: { backgroundColor: "red", color: "white", whiteSpace: "pre-line" }, 
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
      <h4 className="mb-3">{t("tableCampainHeaders.data")}</h4>
      <form onSubmit={handleSubmit} className="row g-3">
        
        {/* الاسم بالعربية */}
        <div className="col-md-6">
          <label className="form-label">{t("Category.nameAr")} </label>
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
          <label className="form-label">{t("Category.nameEn")} </label>
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


        <div className="col-12 d-flex justify-content-center mt-5">
          <button type="submit" className="btn" style={{backgroundColor:"#163a90",color:"white",width:"200px",}}>
           {isEditMode ? t("common.update") : t("common.submit")}
          </button>
        </div>
      </form>
    </div>
  );
};

export default NewCampaign;
