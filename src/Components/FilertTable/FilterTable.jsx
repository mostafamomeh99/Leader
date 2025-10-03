
import React, { useState,useEffect } from "react";
import { useTranslation } from "react-i18next";
import { toast } from "react-toastify";
import { Api_URL } from "../../Resources/ApiUrl";

const FilterTable = ({ onSearch }) => {
      const { t } = useTranslation();
        const [showAdvanced, setShowAdvanced] = useState(false); 
          const [categories, setCategories] = useState([]);
  const [campaigns, setCampaigns] = useState([]);

  const [formData, setFormData] = useState({
    phone: "",
    nationalId: "",
    name: "",
    category: "",
    campaign: "",
     priority: "",
       // advanced
    uploadDate: "",
    attemptDate: "",
    scheduleDate: "",
    assignTo: "",
  });


 useEffect(() => {
    const fetchCategories = async () => {
      try {
        const res = await fetch(`${Api_URL}/CP/v1.0/Category/GetByFilter`, {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({  PageIndex: null,
          PageSize: null,DisplayName: "", CategoryPathName: ""}),
        });
        const data = await res.json();
        if (data?.succeeded && data?.data?.items) {
          // هاخد Id و DisplayName بس
          const mapped = data.data.items.map((c) => ({
            id: c.id,
            name: c.displayName, 
          }));
          setCategories(mapped);
        }
      } catch (err) {
        console.log(err)
          toast.error(
"خطأ فالتحميل", 
                {
                  position: "top-right",
                  style: { backgroundColor: "red", color: "white" },
                }
              );
      }
    };

    const fetchCampaigns = async () => {
      try {
        const body = {
          pageIndex: null,
          pageSize: null,
          displayName: null,
          priorityName: null
        };
        const res = await fetch(`${Api_URL}/CP/v1.0/Campaign/GetByFilter`, {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(body),
        });
        const data = await res.json();
        if (data?.succeeded && data?.data?.items) {
          const mapped = data.data.items.map((c) => ({
            id: c.id,
            name: c.displayName, 
          }));
          setCampaigns(mapped);
        }
      } catch (err) {
      toast.error(
"خطأ فالتحميل", 
                {
                  position: "top-right",
                  style: { backgroundColor: "red", color: "white" },
                }
              );
      }
    };

    fetchCategories();
    fetchCampaigns();
  }, []);
  

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

const handleSearch = () => {
  const mappedFilters = {
    callStatusId: null, 
    idNumber: formData.nationalId || null,
    name: formData.name || null,
    mobile: formData.phone || null,
    categoryId: formData.category || null,
    campaignId: formData.campaign || null,
    priorityId: formData.priority || null,
    callTypeId: null,
    scheduledCallDateRange: formData.scheduleDate
      ? { dateStart: formData.scheduleDate, dateEnd: new Date().toISOString()  }
      : null,
    assignToUserId: formData.assignTo || null,
  };

  onSearch(mappedFilters);
};

  const handleReset = () => {
    const emptyFilters = {
   phone: "",
    nationalId: "",
    name: "",
    category: "",
    campaign: "",
     priority: "",
       // advanced
    uploadDate: "",
    attemptDate: "",
    scheduleDate: "",
    assignTo: "",
    };
    setFormData(emptyFilters);
    onSearch(emptyFilters); //API
  };

  return (<>
    <div className="row mb-3 align-items-end">
      <div className="col-12 col-md-3 mb-2">
        <input
          type="text"
          name="phone"
          placeholder={t("tableHeaders.phone")}
          className="form-control"
          value={formData.phone}
          onChange={handleChange}
        />
      </div>
      <div className="col-12 col-md-3 mb-2">
        <input
          type="text"
          name="nationalId"
          placeholder={t("tableHeaders.nationalId")}
          className="form-control"
          value={formData.nationalId}
          onChange={handleChange}
        />
      </div>
      <div className="col-12 col-md-3 mb-2">
        <input
          type="text"
          name="name"
          placeholder={t("tableHeaders.name")}
          className="form-control"
          value={formData.name}
          onChange={handleChange}
        />
      </div>
      <div className="col-12 col-md-3 mb-2">
        <select
          name="category"
          className="form-select"
          value={formData.category}
          onChange={handleChange}
        >
          <option value="" disabled> {t("tableHeaders.category")}</option>
          {categories.map((c) => (
              <option key={c.id} value={c.id}>
                {c.name}
              </option>
            ))}
        </select>
      </div>
      <div className="col-12 col-md-3 mb-2">
        <select
          name="campaign"
          className="form-select"
          value={formData.campaign}
          onChange={handleChange}
        >
          <option value="" disabled>{t("tableHeaders.campaign")}</option>
          {campaigns.map((c) => (
              <option key={c.id} value={c.id}>
                {c.name}
              </option>
            ))}
        </select>
      </div>


      <div className="col-12 col-md-3 mb-2">
        <select
          name="priority"
          className="form-select"
          value={formData.priority}
          onChange={handleChange}
        >
          <option value="" disabled>{t("tableHeaders.priority")}</option>
          <option value="مرتفعة">مرتفعة</option>
          <option value="متوسطة">متوسطة</option>
          <option value="منخفضة">منخفضة</option>
        </select>
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
          <button
            className="btn btn-primary w-75"
            style={{fontSize:"16px",fontWeight:"700"}}
            onClick={() => setShowAdvanced(!showAdvanced)}
          >
            {showAdvanced ? "-" : "+"}
          </button>
        </div>
    </div>

    {/* advancde search  */}
         {showAdvanced && (
        <div className="row mb-3">
                     <div className="col-12 col-md-3 mb-2">
            <label className="form-label"> {t("advancedFilters.assignTo")}</label>
            <select
              name="assignTo"
              className="form-select"
              value={formData.assignTo}
              onChange={handleChange}
            >
              <option value="" disabled>{t("advancedFilters.assignToEmp")}</option>
              <option value="موظف 1">موظف 1</option>
              <option value="موظف 2">موظف 2</option>
            </select>
          </div>

          <div className="col-12 col-md-3 mb-2">
            <label className="form-label"> {t("advancedFilters.scheduleDate")} </label>
            <input
              type="date"
              name="scheduleDate"
              className="form-control"
              value={formData.scheduleDate}
              onChange={handleChange}
            />
          </div>

          <div className="col-12 col-md-3 mb-2">
            <label className="form-label"> {t("advancedFilters.attemptDate")}</label>
            <input
              type="date"
              name="attemptDate"
              className="form-control"
              value={formData.attemptDate}
              onChange={handleChange}
            />
          </div>

 
           <div className="col-12 col-md-3 mb-2">
            <label className="form-label">{t("advancedFilters.uploadDate")}</label>
            <input
              type="date"
              name="uploadDate"
              className="form-control"
              value={formData.uploadDate}
              onChange={handleChange}
            />
          </div>
        </div>
      )}
</>
  );
};

export default FilterTable;
