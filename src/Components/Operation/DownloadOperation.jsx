
// import { useState } from "react";
// import { useTranslation } from "react-i18next";

// export default function DownloadOperation() {
//   const { t } = useTranslation();
//   const [formData, setFormData] = useState({
//     category: "",
//     campaign: "",
//     priority: "",
//     updateBeneficiaryData: false,
//   });

//   const [errors, setErrors] = useState({});

//   const handleChange = (e) => {
//     const { name, type, value, checked } = e.target;
//     setFormData((prev) => ({
//       ...prev,
//       [name]: type === "checkbox" ? checked : value,
//     }));
//     setErrors((prev) => ({ ...prev, [name]: "" }));
//   };

//   const validate = () => {
//     let newErrors = {};
//     if (!formData.category) newErrors.category = t("operations.errorCategory");
//     if (!formData.campaign) newErrors.campaign = t("operations.errorCampaign");
//     if (!formData.priority) newErrors.priority = t("operations.errorPriority");

//     setErrors(newErrors);
//     return Object.keys(newErrors).length === 0;
//   };

//   const handleSubmit = (e) => {
//     e.preventDefault();
//     if (!validate()) return;
//     console.log("Data to send:", formData);
//   };

//   return (
//     <div className="container mt-5">
//       <form
//         onSubmit={handleSubmit}
//         className="p-4 rounded shadow"
//         style={{ backgroundColor: "#f9f9f9" }}
//         dir="rtl"
//       >
//         {/* Dropdowns */}
//         <div className="row mb-3">
//           <div className="col-md-4">
//             <label className="form-label">{t("operations.selectCategory")}</label>
//             <select
//               name="category"
//               value={formData.category}
//               onChange={handleChange}
//               className={`form-select ${errors.category ? "is-invalid" : ""}`}
//             >
//               <option value="">{t("operations.chooseCategory")}</option>
//               <option value="cat1">تصنيف 1</option>
//               <option value="cat2">تصنيف 2</option>
//             </select>
//             {errors.category && (
//               <div className="invalid-feedback">{errors.category}</div>
//             )}
//           </div>

//           <div className="col-md-4">
//             <label className="form-label">{t("operations.selectCampaign")}</label>
//             <select
//               name="campaign"
//               value={formData.campaign}
//               onChange={handleChange}
//               className={`form-select ${errors.campaign ? "is-invalid" : ""}`}
//             >
//               <option value="">{t("operations.chooseCampaign")}</option>
//               <option value="camp1">حملة 1</option>
//               <option value="camp2">حملة 2</option>
//             </select>
//             {errors.campaign && (
//               <div className="invalid-feedback">{errors.campaign}</div>
//             )}
//           </div>

//           <div className="col-md-4">
//             <label className="form-label">{t("operations.selectPriority")}</label>
//             <select
//               name="priority"
//               value={formData.priority}
//               onChange={handleChange}
//               className={`form-select ${errors.priority ? "is-invalid" : ""}`}
//             >
//               <option value="">{t("operations.choosePriority")}</option>
//               <option value="high">عالية</option>
//               <option value="medium">متوسطة</option>
//               <option value="low">منخفضة</option>
//             </select>
//             {errors.priority && (
//               <div className="invalid-feedback">{errors.priority}</div>
//             )}
//           </div>
//         </div>

//         {/* Checkboxes */}
//         <div className="mt-5">
//           <div className="form-check form-check-inline mb-2">
//             <input
//               className="form-check-input"
//               type="checkbox"
//               name="updateBeneficiaryData"
//               checked={formData.updateBeneficiaryData}
//               onChange={handleChange}
//               id="updateBeneficiaryData"
//             />
//             <label className="form-check-label" htmlFor="updateBeneficiaryData" >
//               {t("operations.updateBeneficiaryData")}
//             </label>
//           </div>
//         </div>

//         {/* Submit Button */}
//         <div className="mt-4 text-center">
//           <button
//             type="submit"
//             className="btn"
//             style={{ backgroundColor: "#293a9b", color: "white" }}
//           >
//             <i className="bi bi-download"></i> {t("operations.downloadTemplate")}
//           </button>
//         </div>
//       </form>
//     </div>
//   );
// }


import { useState } from "react";
import { useTranslation } from "react-i18next";

export default function DownloadOperation() {
  const { t ,i18n} = useTranslation();
  const [formData, setFormData] = useState({
    category: "",
    campaign: "",
    priority: "",
    updateBeneficiaryData: false,
  });

  const [errors, setErrors] = useState({});

  const handleChange = (e) => {
    const { name, type, value, checked } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: type === "checkbox" ? checked : value,
    }));
    setErrors((prev) => ({ ...prev, [name]: "" }));
  };

  const validate = () => {
    let newErrors = {};
    if (!formData.category) newErrors.category = t("operations.errorCategory");
    if (!formData.campaign) newErrors.campaign = t("operations.errorCampaign");
    if (!formData.priority) newErrors.priority = t("operations.errorPriority");

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!validate()) return;
    console.log("Data to send:", formData);
  };

  const handleFileUpload = (e) => {
    const file = e.target.files[0];
    if (file) {
      console.log("File to upload:", file);
    }
  };

  return (
    <div className="container mt-5">
        
        {/* Submit Button */}
        <div className="mt-4 text-left" dir={i18n.language==='en'?"ltr":"rtl"}>
          <button
            className="btn"
            style={{ backgroundColor: "#293a9b", color: "white" }}
            onClick={handleSubmit}
          >
        {t("operations.downloadTemplate")} <i className="bi bi-download"></i>
          </button>
        </div>

      <form
        onSubmit={handleSubmit}
        className="p-4 rounded shadow position-relative mt-3"
        style={{ backgroundColor: "#f9f9f9" }}
        dir={i18n.language==='en'?"ltr":"rtl"}
      >

        {/* Dropdowns */}
        <div className="row mb-3">
          <div className="col-md-4">
            <label className="form-label">{t("operations.selectCategory")}</label>
            <select
              name="category"
              value={formData.category}
              onChange={handleChange}
              className={`form-select ${errors.category ? "is-invalid" : ""}`}
            >
              <option value="">{t("operations.chooseCategory")}</option>
              <option value="cat1">تصنيف 1</option>
              <option value="cat2">تصنيف 2</option>
            </select>
            {errors.category && (
              <div className="invalid-feedback">{errors.category}</div>
            )}
          </div>

          <div className="col-md-4">
            <label className="form-label">{t("operations.selectCampaign")}</label>
            <select
              name="campaign"
              value={formData.campaign}
              onChange={handleChange}
              className={`form-select ${errors.campaign ? "is-invalid" : ""}`}
            >
              <option value="">{t("operations.chooseCampaign")}</option>
              <option value="camp1">حملة 1</option>
              <option value="camp2">حملة 2</option>
            </select>
            {errors.campaign && (
              <div className="invalid-feedback">{errors.campaign}</div>
            )}
          </div>

          <div className="col-md-4">
            <label className="form-label">{t("operations.selectPriority")}</label>
            <select
              name="priority"
              value={formData.priority}
              onChange={handleChange}
              className={`form-select ${errors.priority ? "is-invalid" : ""}`}
            >
              <option value="">{t("operations.choosePriority")}</option>
              <option value="high">عالية</option>
              <option value="medium">متوسطة</option>
              <option value="low">منخفضة</option>
            </select>
            {errors.priority && (
              <div className="invalid-feedback">{errors.priority}</div>
            )}
          </div>
        </div>

        {/* Checkboxes */}
        <div className="mt-5">
          <div className="form-check form-check-inline mb-2">
            <input
              className="form-check-input"
              type="checkbox"
              name="updateBeneficiaryData"
              checked={formData.updateBeneficiaryData}
              onChange={handleChange}
              id="updateBeneficiaryData"
            />
            <label
              className="form-check-label"
              htmlFor="updateBeneficiaryData"
            >
              {t("operations.updateBeneficiaryData")}
            </label>
          </div>
        </div>

        {/* Upload Input */}
        <div className="mt-3 text-center">
          <label
            htmlFor="fileUpload"
            className="btn"
            style={{ backgroundColor: "#293a9b", color: "white", cursor: "pointer" }}
          >
            <i className="bi bi-upload"></i> {t("operations.uploadTemplate")}
          </label>
          <input
            type="file"
            id="fileUpload"
            style={{ display: "none" }}
            onChange={handleFileUpload}
          />
        </div>
      </form>
    </div>
  );
}
