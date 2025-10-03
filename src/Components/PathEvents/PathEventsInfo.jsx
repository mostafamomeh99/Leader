
import { useState, useEffect } from "react";
import styles from "./PathEditInfo.module.css";

function PathEditInfo() {
  const [showPanel, setShowPanel] = useState(false);
  const [activeTab, setActiveTab] = useState("main");
  const [fields, setFields] = useState([]);
  const [selectedReason, setSelectedReason] = useState("");
  const [optionSource, setOptionSource] = useState("custom");

  const [customOptions, setCustomOptions] = useState([]);
  const [systemOptions, setSystemOptions] = useState([
    "ارتفاع سعر المتر عن المشاريع الأخرى",
    "قلة الخدمات المتاحة في المنطقة",
    "زيادة مصاريف الصيانة",
    "الموقع بعيد عن المواصلات",
  ]);
  const [searchTerm, setSearchTerm] = useState("");
  const [newOption, setNewOption] = useState("");

  const addField = (type) => {
    setFields([...fields, type]);
  };

  const addCustomOption = () => {
    if (newOption.trim() !== "") {
      setCustomOptions([...customOptions, newOption]);
      setNewOption("");
    }
  };

  useEffect(() => {
    setSelectedReason("سبب الإلغاء");
  }, []);

  // فلترة القوائم بالبحث
  const filteredSystem = systemOptions.filter((opt) =>
    opt.includes(searchTerm)
  );
  const filteredCustom = customOptions.filter((opt) =>
    opt.includes(searchTerm)
  );

  return (
    <div className={styles.container}>
      <div className={styles.left}>
        <input
          type="text"
          placeholder="اسم المسئولية"
          className={styles.input}
        />

        <select
          className={styles.input}
          onFocus={() => setShowPanel(true)}
          value={selectedReason}
          onChange={(e) => setSelectedReason(e.target.value)}
        >
          <option value="سبب الإلغاء">سبب الإلغاء</option>
          <option value="سبب 1">سبب 1</option>
          <option value="سبب 2">سبب 2</option>
        </select>

        <input
          type="text"
          placeholder="المسئولية"
          className={styles.input}
        />
      </div>

      {showPanel && (
        <div className={styles.right}>
          <div className={styles.navbar}>
            <button
              className={activeTab === "main" ? styles.activeBtn : ""}
              onClick={() => setActiveTab("main")}
            >
              الصفحة الرئيسية
            </button>
            <button
              className={activeTab === "fieldOptions" ? styles.activeBtn : ""}
              onClick={() => setActiveTab("fieldOptions")}
            >
              خيارات الحقل
            </button>
            <button
              className={activeTab === "conditions" ? styles.activeBtn : ""}
              onClick={() => setActiveTab("conditions")}
            >
              شروط الإظهار
            </button>
          </div>

          <div className={styles.tabContent}>
            {activeTab === "main" && (
              <div>
                <p>العنوان</p>
                <input
                  type="text"
                  placeholder="سبب الالغاء"
                  className={styles.input}
                  value={selectedReason}
                  onChange={(e) => setSelectedReason(e.target.value)}
                />
                <p>النوع</p>
                <select className={styles.input}>
                  <option value="اختيار واحد">اختيار واحد</option>
                  <option value="اختيار اكتر من واحد">
                    اختيار اكتر من واحد
                  </option>
                </select>

                <div className={styles.checkboxRow}>
                  <input
                    type="checkbox"
                    id="mandatoryField"
                    className={styles.checkbox}
                  />
                  <label htmlFor="mandatoryField">
                    هل الحقل إجبارى عند الظهور فى المسار؟
                  </label>
                </div>

                <div className={styles.checkboxRow}>
                  <input
                    type="checkbox"
                    id="readOnlyField"
                    className={styles.checkbox}
                  />
                  <label htmlFor="readOnlyField">هل الحقل للقراءة فقط؟</label>
                </div>

                <div className={styles.checkboxRow}>
                  <input
                    type="checkbox"
                    id="exportableField"
                    className={styles.checkbox}
                  />
                  <label htmlFor="exportableField">
                    هل الحقل قابل للتصدير؟
                  </label>
                </div>
              </div>
            )}

            {activeTab === "fieldOptions" && (
              <div>
                <p>هنا خيارات الحقل</p>

                {/* اختيار مصدر البيانات */}
                <div className={styles.radioGroup}>
                  <label className={styles.radioLabel}>
                    <input
                      type="radio"
                      name="optionSource"
                      value="custom"
                      checked={optionSource === "custom"}
                      onChange={(e) => setOptionSource(e.target.value)}
                    />
                    خيارات مخصصة
                  </label>

                  <label className={styles.radioLabel}>
                    <input
                      type="radio"
                      name="optionSource"
                      value="system"
                      checked={optionSource === "system"}
                      onChange={(e) => setOptionSource(e.target.value)}
                    />
                    خيارات من كيان النظام
                  </label>
                </div>

                {/* حقل بحث */}
                <input
                  type="text"
                  className={styles.input}
                  placeholder="ابحث هنا..."
                  value={searchTerm}
                  onChange={(e) => setSearchTerm(e.target.value)}
                />

                {/*  كيان النظام */}
                {/* {optionSource === "system" && (
                    <>                  <button onClick={addCustomOption}>+ إضافة</button>
                  <ul className={styles.optionList}>
                    {filteredSystem.map((opt, idx) => (
                      <li key={idx}>{opt}</li>
                    ))}
                    {filteredSystem.length === 0 && <li>لا توجد نتائج</li>}
                  </ul>
                  </>
                )} */}
                {optionSource === "system" && (
  <div>
    <input
      type="text"
      className={styles.input}
      placeholder="أضف خيار جديد للنظام..."
      value={newOption}
      onChange={(e) => setNewOption(e.target.value)}
    />
    <button
      className={styles.addButton}
      onClick={() => {
        if (newOption.trim() !== "") {
          setSystemOptions([...systemOptions, newOption]); 
          setNewOption("");
        }
      }}
    >
      + إضافة
    </button>

    {/* <ul className={styles.optionList}>
      {filteredSystem.map((opt, idx) => (
        <li key={idx}>{opt}</li>
      ))}
      {filteredSystem.length === 0 && <li>لا توجد نتائج</li>}
    </ul> */}

    <ul className={`mt-2 ${styles.optionList}`}>
  {filteredSystem.map((opt, idx) => (
    <li key={idx} className={styles.optionItem}>
      {opt}
      <span
        className={styles.deleteBtn}
        onClick={() =>
          setSystemOptions(systemOptions.filter((o) => o !== opt))
        }
      >
        ❌
      </span>
    </li>
  ))}
  {filteredSystem.length === 0 && <li>لا توجد نتائج</li>}
</ul>

  </div>
)}

                {/*  كيان مخصص */}
                {optionSource === "custom" && (
                  <div>
                    <input
                      type="text"
                      className={styles.input}
                      placeholder="أضف خيار جديد..."
                      value={newOption}
                      onChange={(e) => setNewOption(e.target.value)}
                    />
                    <button onClick={addCustomOption}       className={styles.addButton}>+ إضافة</button>

                    <ul className={styles.optionList}>
                      {filteredCustom.map((opt, idx) => (
                        <li key={idx}>{opt}</li>
                      ))}
                      {filteredCustom.length === 0 && (
                        <li>لا توجد خيارات مضافة</li>
                      )}
                    </ul>
                  </div>
                )}
              </div>
            )}

            {activeTab === "conditions" && (
              <div>
                <p>هنا شروط الإظهار</p>
                <input className={styles.input} placeholder="شرط الإظهار" />
              </div>
            )}
          </div>
        </div>
      )}
    </div>
  );
}

export default PathEditInfo;
