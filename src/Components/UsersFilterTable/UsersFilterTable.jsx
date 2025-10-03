
// old static version 

// import React, { useState } from "react";
// import { useTranslation } from "react-i18next";
// import {Link} from 'react-router-dom'
// const UserFilterTable = ({ onSearch }) => {
//       const { t } = useTranslation();
//     const [formData, setFormData] = useState({
//     name: "",
//     phone: "",
//     nationalId: "",
//     email: "",
//     team: "",
//     username: "",
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
//     phone: "",
//     nationalId: "",
//     email: "",
//     team: "",
//     username: "",
//     };
//     setFormData(emptyFilters);
//     onSearch(emptyFilters); //API
//   };

//   return (<>
//     <div className="row mb-3 align-items-end">
//       <div className="col-12 col-md-3 mb-2">
//         <input
//           type="text"
//           name="phone"
//           placeholder={t("tableHeaders.phone")}
//           className="form-control"
//           value={formData.phone}
//           onChange={handleChange}
//         />
//       </div>
//       <div className="col-12 col-md-3 mb-2">
//         <input
//           type="text"
//           name="nationalId"
//           placeholder={t("tableHeaders.nationalId")}
//           className="form-control"
//           value={formData.nationalId}
//           onChange={handleChange}
//         />
//       </div>
//       <div className="col-12 col-md-3 mb-2">
//         <input
//           type="text"
//           name="name"
//           placeholder={t("tableHeaders.name")}
//           className="form-control"
//           value={formData.name}
//           onChange={handleChange}
//         />
//       </div>
//    {/* البريد الإلكتروني */}
//         <div className="col-12 col-md-3 mb-2">
//           <input
//             type="email"
//             name="email"
//             placeholder={t("tableUserHeaders.email")}
//             className="form-control"
//             value={formData.email}
//             onChange={handleChange}
//           />
//         </div>




//      {/* الفريق */}
//         <div className="col-12 col-md-3 mb-2">
//           <select
//             name="team"
//             className="form-select"
//             value={formData.team}
//             onChange={handleChange}
//           >
//             <option value="">{t("tableUserHeaders.team")}</option>
//             <option value="teamA">فريق A / Team A</option>
//             <option value="teamB">فريق B / Team B</option>
//           </select>
//         </div>

//         {/* اسم المستخدم */}
//         <div className="col-12 col-md-3 mb-2">
//           <input
//             type="text"
//             name="username"
//             placeholder={t("tableUserHeaders.username")}
//             className="form-control"
//             value={formData.username}
//             onChange={handleChange}
//           />
//         </div>


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
//           <Link to={'/newregister'}>
//           <button
//             className="btn btn-primary "
//             style={{fontSize:"16px",fontWeight:"700",width:"300px"}}
    
//           >
//            + {t("tableUserHeaders.addUser")}
//           </button>
//           </Link>
//         </div>
//     </div>


// </>
//   );
// };

// export default UserFilterTable;


import React, { useState } from "react";
import { useTranslation } from "react-i18next";
import { Link } from "react-router-dom";
import { toast } from "react-toastify";

const UsersFilterTable = ({ onSearch }) => {
  const { t } = useTranslation();

  const [formData, setFormData] = useState({
    fullName: "",
    phoneNumber: "",
    employeeNumber: "",
    email: "",
    teamId: "",
    userName: "",
    extension: "",
    roleId: "",
    isStillEmployee: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSearch = () => {

     const hasAnyValue = Object.values(formData).some((val) => val !== "" && val !== null);

    if (!hasAnyValue) {
      toast.error(
        t("errors.atLeastOneFilter") || "Please enter at least one filter value",
        {
          position: "top-right",
          style: { backgroundColor: "red", color: "white" },
        }
      );
      return;
    }
   
    const filters = {
      ...formData,
      isStillEmployee:
        formData.isStillEmployee === ""
          ? null
          : formData.isStillEmployee === "true",
    };
    onSearch(filters);
  };

  const handleReset = () => {
    const emptyFilters = {
      fullName: "",
      phoneNumber: "",
      employeeNumber: "",
      email: "",
      teamId: "",
      userName: "",
      extension: "",
      roleId: "",
      isStillEmployee: "",
    };
    setFormData(emptyFilters);
    onSearch(emptyFilters);
  };

  return (
    <div className="row mb-3 align-items-end">
      {/* الاسم */}
      <div className="col-12 col-md-3 mb-2">
        <input
          type="text"
          name="fullName"
          placeholder={t("tableUserHeaders.empName")}
          className="form-control"
          value={formData.fullName}
          onChange={handleChange}
        />
      </div>

      {/* رقم الهاتف */}
      <div className="col-12 col-md-3 mb-2">
        <input
          type="text"
          name="phoneNumber"
          placeholder={t("tableUserHeaders.phone")}
          className="form-control"
          value={formData.phoneNumber}
          onChange={handleChange}
        />
      </div>

      {/* رقم الموظف */}
      <div className="col-12 col-md-3 mb-2">
        <input
          type="text"
          name="employeeNumber"
          placeholder={t("tableUserHeaders.empId")}
          className="form-control"
          value={formData.employeeNumber}
          onChange={handleChange}
        />
      </div>

      {/* الاكستنشن */}
      <div className="col-12 col-md-3 mb-2">
        <input
          type="text"
          name="extension"
          placeholder={t("tableUserHeaders.extension")}
          className="form-control"
          value={formData.extension}
          onChange={handleChange}
        />
      </div>

      {/* اسم المستخدم */}
      <div className="col-12 col-md-3 mb-2">
        <input
          type="text"
          name="userName"
          placeholder={t("tableUserHeaders.username")}
          className="form-control"
          value={formData.userName}
          onChange={handleChange}
        />
      </div>

      {/* البريد الإلكتروني */}
      <div className="col-12 col-md-3 mb-2">
        <input
          type="email"
          name="email"
          placeholder={t("tableUserHeaders.email")}
          className="form-control"
          value={formData.email}
          onChange={handleChange}
        />
      </div>

      {/* الفريق */}
      <div className="col-12 col-md-3 mb-2">
        <select
          name="teamId"
          className="form-select"
          value={formData.teamId}
          onChange={handleChange}
        >
          <option value="">{t("tableUserHeaders.team")}</option>
          <option value="guidTeamA">فريق A / Team A</option>
          <option value="guidTeamB">فريق B / Team B</option>
        </select>
      </div>

      {/* الدور */}
      <div className="col-12 col-md-3 mb-2">
        <select
          name="roleId"
          className="form-select"
          value={formData.roleId}
          onChange={handleChange}
        >
          <option value="">{t("tableUserHeaders.role")}</option>
          <option value="guidRole1">مشرف</option>
          <option value="guidRole2">موظف خدمة عملاء</option>
        </select>
      </div>

      {/* الحالة */}
      <div className="col-12 col-md-3 mb-2">
        <select
          name="isStillEmployee"
          className="form-select"
          value={formData.isStillEmployee}
          onChange={handleChange}
        >
          <option value="">{t("tableUserHeaders.status")}</option>
          <option value="true">{t("active")}</option>
          <option value="false">{t("inactive")}</option>
        </select>
      </div>

      {/* زرار البحث */}
      <div className="col-12 col-md-1 mb-2">
        <button className="btn btn-primary w-100" onClick={handleSearch}>
          <i className="bi bi-search"></i>
        </button>
      </div>

      {/* زرار إعادة التصفية */}
      <div className="col-12 col-md-1 mb-2">
        <button className="btn btn-danger w-100" onClick={handleReset}>
          {t("resetSearch")}
        </button>
      </div>

      {/* إضافة مستخدم */}
      <div className="col-4 col-md-1 mb-2">
        <Link to={"/newregister"}>
          <button
            className="btn btn-primary "
            style={{ fontSize: "16px", fontWeight: "700", width: "300px" }}
          >
            + {t("tableUserHeaders.addUser")}
          </button>
        </Link>
      </div>
    </div>
  );
};

export default UsersFilterTable;
