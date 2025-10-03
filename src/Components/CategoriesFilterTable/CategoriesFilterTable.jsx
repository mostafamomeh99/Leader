// old-static

// import React, { useState } from "react";
// import { useTranslation } from "react-i18next";
// import {Link} from 'react-router-dom'
// const CategoriesFilterTable = ({ onSearch }) => {
//       const { t } = useTranslation();
//     const [formData, setFormData] = useState({
//     name: "",
//     path: "",
//   });

//   const handleChange = (e) => {
//     const { name, value } = e.target;
//     setFormData((prev) => ({
//       ...prev,
//       [name]: value,
//     }));
//   };

//   const handleSearch = () => {
//     onSearch(formData); // API
//   };

//   const handleReset = () => {
//     const emptyFilters = {
//     name: "",
//     path: "",
//     };
//     setFormData(emptyFilters);
//     onSearch(emptyFilters); //API
//   };

//   return (<>
//     <div className="row mb-3 align-items-end">
//       <div className="col-12 col-md-3 mb-2">
//         <input
//           type="text"
//           name="path"
//           placeholder={t("tableCategoryHeaders.categoryPath")}
//           className="form-control"
//           value={formData.path}
//           onChange={handleChange}
//         />
//       </div>
//       <div className="col-12 col-md-3 mb-2">
//         <input
//           type="text"
//           name="name"
//           placeholder={t("tableCategoryHeaders.categoryName")}
//           className="form-control"
//           value={formData.name}
//           onChange={handleChange}
//         />
//       </div>



//       <div className="col-12 col-md-1 mb-2">
//         <button className="btn btn-primary w-100" onClick={handleSearch}>
//           <i className="bi bi-search"></i>
//         </button>
//       </div>
//       <div className="col-12 col-md-1 mb-2">
//         <button className="btn btn-danger w-100" onClick={handleReset}>
//            {t("resetSearch")}
//         </button>
//       </div>

      
//         <div className="col-4 col-md-1 mb-2">
//           <Link to={'/newCategory'}>
//           <button
//             className="btn btn-primary "
//             style={{fontSize:"16px",fontWeight:"700",width:"300px"}}
    
//           >
//            + {t("tableCategoryHeaders.addCategory")}
//           </button>
//           </Link>
//         </div>
//     </div>


// </>
//   );
// };

// export default CategoriesFilterTable;

//front

// import React, { useState } from "react";
// import { useTranslation } from "react-i18next";
// import { Link } from "react-router-dom";
// import { toast } from "react-toastify";

// const CategoriesFilterTable = ({ onSearch }) => {
//   const { t } = useTranslation();
//   const [formData, setFormData] = useState({
//     name: "",
//     path: "",
//   });

//   const handleChange = (e) => {
//     const { name, value } = e.target;
//     setFormData((prev) => ({
//       ...prev,
//       [name]: value,
//     }));
//   };

//   const handleSearch = () => {
//     if (!formData.name && !formData.path) {
//       toast.error(
//         t("errors.atLeastOneFilter") ||
//           "Please enter at least one filter value",
//         {
//           position: "top-right",
//           style: { backgroundColor: "red", color: "white" },
//         }
//       );
//       return;
//     }
//     onSearch(formData);
//   };

//   const handleReset = () => {
//     const emptyFilters = { name: "", path: "" };
//     setFormData(emptyFilters);
//     onSearch(emptyFilters);
//   };

//   return (
//     <div className="row mb-3 align-items-end">
//       <div className="col-12 col-md-3 mb-2">
//         <input
//           type="text"
//           name="name"
//           placeholder={t("tableCategoryHeaders.category")}
//           className="form-control"
//           value={formData.name}
//           onChange={handleChange}
//         />
//       </div>
//       <div className="col-12 col-md-3 mb-2">
//         <input
//           type="text"
//           name="path"
//           placeholder={t("tableCategoryHeaders.categoryPath")}
//           className="form-control"
//           value={formData.path}
//           onChange={handleChange}
//         />
//       </div>

//       <div className="col-12 col-md-1 mb-2">
//         <button className="btn btn-primary w-100" onClick={handleSearch}>
//           <i className="bi bi-search"></i>
//         </button>
//       </div>
//       <div className="col-12 col-md-1 mb-2">
//         <button className="btn btn-danger w-100" onClick={handleReset}>
//           {t("resetSearch")}
//         </button>
//       </div>

//       <div className="col-4 col-md-1 mb-2">
//         <Link to={"/NewCategory"}>
//           <button
//             className="btn btn-primary"
//             style={{ fontSize: "16px", fontWeight: "700", width: "300px" }}
//           >
//             + {t("tableCategoryHeaders.addCategory")}
//           </button>
//         </Link>
//       </div>
//     </div>
//   );
// };

// export default CategoriesFilterTable;


// backend version

import React, { useState } from "react";
import { useTranslation } from "react-i18next";
import { Link } from "react-router-dom";
import { toast } from "react-toastify";

const CategoriesFilterTable = ({ onSearch }) => {
  const { t, i18n } = useTranslation();
  const [formData, setFormData] = useState({
    name: "",
    path: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSearch = () => {
    if (!formData.name && !formData.path) {
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
    const emptyFilters = { name: "", path: "" };
    setFormData(emptyFilters);
    onSearch(emptyFilters);
  };

  return (
    <div className="row mb-3 align-items-end">
      <div className="col-12 col-md-3 mb-2">
        <input
          type="text"
          name="name"
          placeholder={t("tableCategoryHeaders.category")}
          className="form-control"
          value={formData.name}
          onChange={handleChange}
        />
      </div>
      <div className="col-12 col-md-3 mb-2">
        <input
          type="text"
          name="path"
          placeholder={t("tableCategoryHeaders.categoryPath")}
          className="form-control"
          value={formData.path}
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
        <Link to={"/NewCategory"}>
          <button
            className="btn btn-primary"
            style={{ fontSize: "16px", fontWeight: "700", width: "300px" }}
          >
            + {t("tableCategoryHeaders.addCategory")}
          </button>
        </Link>
      </div>
    </div>
  );
};

export default CategoriesFilterTable;
