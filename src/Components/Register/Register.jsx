

import { useState, useEffect } from "react";
import { useTranslation } from "react-i18next";
import { useParams } from "react-router-dom";
import { toast } from "react-toastify";
import { Api_URL } from "../../Resources/ApiUrl";
import styles from "./Register.module.css";

const Register = () => {
  const { t } = useTranslation();
  const { userId } = useParams();
  const [isEditMode, setIsEditMode] = useState(false);

  const [form, setForm] = useState({
    username: "",
    FullNameAr:"",
    usernameEn: "",
    nationalId: "",
    extension: "",
    manager: "",
    email: "",
    phone: "",
    password: "",
    confirmPassword: "",
    PermessionIds: [],
    RoleIds:[],
    CategoryIds:[],
        Notes:"default"
  });

  const [errors, setErrors] = useState({});
  const [search, setSearch] = useState("");

  // mock permissions
const allPermissions =  [
  { id: "746F79EE-BC4A-4E58-95D2-01C73CF3A868", nameAr: "منظم التقارير" },
  { id: "B57D5DA1-98E7-4C98-AC00-104919CB8E8D", nameAr: "النظام" },
  { id: "93B91E52-5850-4190-9E87-2A1BFBD81910", nameAr: "المشرف" },
  { id: "24E65B31-A815-4FB0-A5FA-4B78AAB03C72", nameAr: "مسؤول النظام" },
  { id: "AD0B3B57-295F-4312-BBA1-B09A11865237", nameAr: "موظف" },
  { id: "5918287C-140D-4938-A8EE-D3A3099EC957", nameAr: "المسؤول" },
  { id: "6FDD3E8A-EBFC-4FE5-8A48-ED2BDE9FB2AD", nameAr: "قائد الفريق" }
];

const roles = [
  { id: "746F79EE-BC4A-4E58-95D2-01C73CF3A868", nameAr: "منظم التقارير" },
  { id: "B57D5DA1-98E7-4C98-AC00-104919CB8E8D", nameAr: "النظام" },
  { id: "93B91E52-5850-4190-9E87-2A1BFBD81910", nameAr: "المشرف" },
  { id: "24E65B31-A815-4FB0-A5FA-4B78AAB03C72", nameAr: "مسؤول النظام" },
  { id: "AD0B3B57-295F-4312-BBA1-B09A11865237", nameAr: "موظف" },
  { id: "5918287C-140D-4938-A8EE-D3A3099EC957", nameAr: "المسؤول" },
  { id: "6FDD3E8A-EBFC-4FE5-8A48-ED2BDE9FB2AD", nameAr: "قائد الفريق" }
];
  // Edit mode
  useEffect(() => {
    if (userId) {
      setIsEditMode(true);
      const fetchUser = async () => {
        try {
          const res = await fetch(`${Api_URL}/CP/v1.0/User/GetUserById`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(userId),
          });

          if (res.ok) {
            const data = await res.json();
            const user = data.data || {};

            setForm({
              username: user.userName || "",
              FullNameAr: user.fullNameAr || "",
              nationalId: user.identityNumber || "",
              // extension: user.extension || "",
                // FullNameEn: user.FullNameEn || "",
              manager: user.manager || "",
              email: user.email || "",
              phone: user.phoneNumber || "",
              password: "",
              confirmPassword: "",
              PermessionIds:  [],
              RoleIds:user.roleIds || [],
              CategoryIds:[]
            });
          } else {
            const errorData = await res.json();
            toast.error(errorData.message || t("common.failedOperation"), {
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
      fetchUser();
    }
  }, [userId]);


  const validate = () => {
    let newErrors = {};

    if (!form.FullNameAr.trim()) {
      newErrors.FullNameAr = t("errors.fullNameAr");
    } else if (!/[\u0600-\u06FFa-zA-Z]{3,}/.test(form.FullNameAr)) {
      newErrors.FullNameAr = t("errors.fullNameArInvalid");
    }

        if (!form.username.trim()||!/[A-Za-z]{3,}/.test(form.username)) {
        newErrors.username = t("errors.username");
    }

    // if (!form.usernameEn.trim()) {
    //   if (!/[A-Za-z]{3,}/.test(form.usernameEn)) {
    //     newErrors.usernameEn = t("errors.fullNameEn");
    //   }
    // }

    if (!form.nationalId.trim()) {
      newErrors.nationalId = t("errors.nationalIdRequired");
    } else if (!/^\d{14}$/.test(form.nationalId)) {
      newErrors.nationalId = t("errors.nationalId");
    }

    if (!form.extension.trim()) {
      newErrors.extension = t("errors.extensionRequired");
    } else if (!/^\d{3,5}$/.test(form.extension)) {
      newErrors.extension = t("errors.extensionInvalid");
    }

    if (form.manager.trim() === "") {
      newErrors.manager = t("errors.managerRequired");
    }

    if (!form.email.trim()) {
      newErrors.email = t("errors.emailRequired");
    } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(form.email)) {
      newErrors.email = t("errors.email");
    }

    if (!form.phone.trim()) {
      newErrors.phone = t("errors.phoneRequired");
    } else if (!/^\d{11}$/.test(form.phone)) {
      newErrors.phone = t("errors.phone");
    }

    if (!form.password.trim()) {
      newErrors.password = t("errors.passwordRequired");
    } else if (form.password.length < 6) {
      newErrors.password = t("errors.password");
    }

    if (!form.confirmPassword.trim()) {
      newErrors.confirmPassword = t("errors.confirmPasswordRequired");
    } else if (form.confirmPassword.length < 6) {
      newErrors.confirmPassword = t("errors.password");
    } else if (form.password !== form.confirmPassword) {
      newErrors.confirmPassword = t("errors.confirmPassword");
    }

    if (form.RoleIds.length === 0) {
      newErrors.permissions = t("errors.permissionsRequired");
    }

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };


  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!validate()) return;

    try {
      const url = isEditMode
        ? `${Api_URL}/CP/v1.0/User/Edit`
        : `${Api_URL}/CP/v1.0/User/NewApplicationUser`;


      const bodyData = {
        Id: isEditMode ? userId : null,
        FullNameAr: form.FullNameAr,
        UserName: form.username,
        IdentityNumber: form.nationalId,
        PhoneNumber: form.phone,
        Email: form.email,
        Password: form.password,
        ConfirmPassword: form.confirmPassword,
        // PermissionIds: form.PermessionIds,
        PermessionIds:[],
        RoleIds:form.RoleIds||[],
        Notes:"default",
        CategoryIds:[]
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

  // permissions filter
 const filteredPermissions = allPermissions.filter((p) =>
  p.nameAr.toLowerCase().includes(search.toLowerCase())
);

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

const handlePermissionChange = (permissionId) => {
  setForm((prev) => {
    if (prev.RoleIds.includes(permissionId)) {
      return {
        ...prev,
        RoleIds: prev.RoleIds.filter((p) => p !== permissionId),
      };
    } else {
      return { ...prev, RoleIds: [...prev.RoleIds, permissionId] };
    }
  });
};

  return (
    <div className={`container ${styles.container}`}>
      <h4 className="text-center mb-5 text-white">
        {isEditMode ? t("common.updateUser") : t("common.addUser")}
      </h4>

      <form onSubmit={handleSubmit} className="row g-3">
        {/* Row 1 */}
        <div className="row mb-3">
          <div className="col-md-6">
            <label className={`form-label ${styles.label}`}>
              {t("register.fullNameAr")} *
            </label>
            <input
              type="text"
              name="FullNameAr"
              className={`form-control ${errors.FullNameAr ? "is-invalid" : ""}`}
              value={form.FullNameAr}
              onChange={handleChange}
            />
            {errors.FullNameAr && (
              <div className={styles.error}>{errors.FullNameAr}</div>
            )}
          </div>

          {/* <div className="col-md-6">
            <label className={`form-label ${styles.label}`}>
              {t("register.fullNameEn")}
            </label>
            <input
              type="text"
              name="usernameEn"
              className={`form-control ${errors.usernameEn ? "is-invalid" : ""}`}
              value={form.usernameEn}
              onChange={handleChange}
            />
            {errors.usernameEn && <div className={styles.error}>{errors.usernameEn}</div>}
          </div> */}
                    <div className="col-md-6">
            <label className={`form-label ${styles.label}`}>
              {t("register.username")} *
            </label>
            <input
              type="text"
              name="username"
              className={`form-control ${errors.username ? "is-invalid" : ""}`}
              value={form.username}
              onChange={handleChange}
            />
            {errors.username && <div className={styles.error}>{errors.username}</div>}
          </div>
        </div>

        {/* Row 2 */}
        <div className="row mb-3">
          <div className="col-md-6">
            <label className={`form-label ${styles.label}`}>
              {t("register.nationalId")} *
            </label>
            <input
              type="text"
              name="nationalId"
              className={`form-control ${errors.nationalId ? "is-invalid" : ""}`}
              value={form.nationalId}
              onChange={handleChange}
            />
            {errors.nationalId && <div className={styles.error}>{errors.nationalId}</div>}
          </div>

          <div className="col-md-6">
            <label className={`form-label ${styles.label}`}>
              {t("register.extension")} *
            </label>
            <input
              type="text"
              name="extension"
              className={`form-control ${errors.extension ? "is-invalid" : ""}`}
              value={form.extension}
              onChange={handleChange}
            />
            {errors.extension && <div className={styles.error}>{errors.extension}</div>}
          </div>
</div>

        {/* Row 3 */}
        <div className="row mb-3">
          <div className="col-md-6">
            <label className={`form-label ${styles.label}`}>{t("register.email")} *</label>
            <input
              type="email"
              name="email"
              className={`form-control ${errors.email ? "is-invalid" : ""}`}
              value={form.email}
              onChange={handleChange}
            />
            {errors.email && <div className={styles.error}>{errors.email}</div>}
          </div>

          <div className="col-md-6">
            <label className={`form-label ${styles.label}`}>
              {t("register.phone")} *
            </label>
            <input
              type="text"
              name="phone"
              className={`form-control ${errors.phone ? "is-invalid" : ""}`}
              value={form.phone}
              onChange={handleChange}
            />
            {errors.phone && <div className={styles.error}>{errors.phone}</div>}
          </div>
        </div>

        {/* Row 4 → Passwords */}
        <div className="row mb-3">
          <div className="col-md-6">
            <label className={`form-label ${styles.label}`}>
              {t("register.password")} *
            </label>
            <input
              type="password"
              name="password"
              className={`form-control ${errors.password ? "is-invalid" : ""}`}
              value={form.password}
              onChange={handleChange}
            />
            {errors.password && <div className={styles.error}>{errors.password}</div>}
          </div>

          <div className="col-md-6">
            <label className={`form-label ${styles.label}`}>
              {t("register.confirmPassword")} *
            </label>
            <input
              type="password"
              name="confirmPassword"
              className={`form-control ${errors.confirmPassword ? "is-invalid" : ""}`}
              value={form.confirmPassword}
              onChange={handleChange}
            />
            {errors.confirmPassword && <div className={styles.error}>{errors.confirmPassword}</div>}
          </div>
        </div>

        {/* Row 5 → Manager */}
        <div className="row mb-3">
          <div className="col-md-6">
            <label className={`form-label ${styles.label}`}>{t("register.manager")} *</label>
            <select
              name="manager"
              className={`form-control ${errors.manager ? "is-invalid" : ""}`}
              value={form.manager}
              onChange={handleChange}
            >
              <option value="">{t("register.manager")}</option>
              <option value="directManager">{t("register.managerOptions.option1")}</option>
              <option value="hrManager">{t("register.managerOptions.option2")}</option>
              <option value="techManager">{t("register.managerOptions.option3")}</option>
            </select>
            {errors.manager && <div className={styles.error}>{errors.manager}</div>}
          </div>
        </div>




        {/* Permissions */}
<div className="mb-4">
  <label className={`form-label ${styles.label}`}>
    {t("register.permissions")}
  </label>
  <input
    type="text"
    placeholder={t("register.searchPermissions")}
    className="form-control mb-2"
    value={search}
    onChange={(e) => setSearch(e.target.value)}
  />
  <div className="d-flex flex-column gap-2" style={{ color: "black" }}>
    {filteredPermissions.map((permission) => (
      <div key={permission.id} className="form-check">
        <input
          type="checkbox"
          className="form-check-input"
          id={permission.id}
          checked={form.RoleIds.includes(permission.id)}
          onChange={() => handlePermissionChange(permission.id)}
        />
        <label className="form-check-label" htmlFor={permission.id}>
          {permission.nameAr}
        </label>
      </div>
    ))}
  </div>
  {errors.permissions && (
    <div className={styles.error}>{errors.permissions}</div>
  )}
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

export default Register;
