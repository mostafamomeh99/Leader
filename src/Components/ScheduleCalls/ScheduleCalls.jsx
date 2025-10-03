
import { useState, useContext } from "react";
import { useTranslation } from "react-i18next";
import { AppContext } from "../../StateMangment";
import styles from './ScheduleCalls.module.css';
const mockPath = {
  pathId: 1,
  name: "مسار المكالمة",
  questions: [
    {
      id: 1,
      text: "هل توافق على استكمال المكالمة؟",
      answers: [
        { id: 1, text: "نعم", nextQuestionId: 2 },
        { id: 2, text: "لا", nextQuestionId: 3 },
      ],
    },
    {
      id: 2,
      text: "هل أنت المستفيد؟",
      answers: [
        { id: 3, text: "نعم", nextQuestionId: 4 },
        { id: 4, text: "لا", nextQuestionId: null },
      ],
    },
    {
      id: 3,
      text: "هل ترغب في إنهاء المكالمة؟",
      answers: [],
    },
    {
      id: 4,
      text: "هل ترغب في استلام رسائل نصية؟",
      answers: [
        { id: 5, text: "نعم", nextQuestionId: null },
        { id: 6, text: "لا", nextQuestionId: null },
      ],
    },
  ],
};

export default function CallInfoForm() {
  const { t, i18n } = useTranslation();
  const { direction } = useContext(AppContext);

  const [status, setStatus] = useState("");
  const [campaign, setCampaign] = useState("حملة رمضان");
  const [beneficiaryName, setBeneficiaryName] = useState("");
  const [nationalId, setNationalId] = useState("");
  const [phone, setPhone] = useState("");
  const [address, setAddress] = useState("");

  const [answers, setAnswers] = useState({});
  const [visibleQuestions, setVisibleQuestions] = useState([mockPath.questions[0].id]);

  const handleAnswer = (questionId, answer) => {
    setAnswers((prev) => ({ ...prev, [questionId]: answer.text }));
         
    if (answer.nextQuestionId && !visibleQuestions.includes(answer.nextQuestionId)) {
      setVisibleQuestions((prev) => [...prev, answer.nextQuestionId]);
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const formData = {
      status,
      campaign,
      beneficiaryName,
      nationalId,
      phone,
      address,
      pathId: mockPath.pathId,
      answers,
    };

    console.log("Submitted Data:", formData);
    alert("✅ تم إرسال بيانات المكالمة مع المسار");
  };

  return (
    <div className="container mt-4" dir={direction}>
      <div className="card shadow p-3 rounded-3">
        <div className="card-body">
          <h4 className="mb-4">
            <i className="bi bi-telephone-fill"></i> {t("callInfo.title")}
          </h4>

          <form onSubmit={handleSubmit}>
            {/* حالة المكالمة */}
            <div className="mb-3">
              <label className="form-label">{t("callInfo.status")}</label>
              <select
                className="form-select"
                value={status}
                onChange={(e) => setStatus(e.target.value)}
              >
                <option value="">{t("callInfo.status")}</option>
                <option value="نجاح">{t("callInfo.success")}</option>
                <option value="لم يرد">{t("callInfo.noAnswer")}</option>
                <option value="مشغول">{t("callInfo.busy")}</option>
                <option value="مرفوض">{t("callInfo.rejected")}</option>
              </select>
            </div>

            {/* الحملة */}
            <div className="mb-3">
              <label className="form-label">{t("callInfo.campaign")}</label>
              <select className="form-select" value={campaign} disabled>
                <option>{campaign}</option>
              </select>
            </div>

            {/* بيانات المستفيد */}
            <h5 className="mt-4">
              <i className="bi bi-person-fill"></i>{" "}
              {t("callInfo.titleInfoBeneficiary")}
            </h5>

<div className="row mt-3">
  <div className="col-md-6 mb-3">
    <label className="form-label">{t("callInfo.beneficiaryName")}</label>
    <input
      type="text"
      className="form-control"
      value={beneficiaryName}
      onChange={(e) => setBeneficiaryName(e.target.value)}
    />
  </div>

  <div className="col-md-6 mb-3">
    <label className="form-label">{t("callInfo.nationalId")}</label>
    <input
      type="text"
      className="form-control"
      value={nationalId}
      onChange={(e) => setNationalId(e.target.value)}
    />
  </div>
</div>

<div className="row">
  <div className="col-md-6 mb-3">
    <label className="form-label">{t("callInfo.phone")}</label>
    <input
      type="text"
      className="form-control"
      value={phone}
      onChange={(e) => setPhone(e.target.value)}
    />
  </div>
    </div>
            {/* <div className="mb-3">
              <label className="form-label">{t("callInfo.address")}</label>
              <input
                type="text"
                className="form-control"
                value={address}
                onChange={(e) => setAddress(e.target.value)}
              />
            </div> */}

            {/*المسار ا   */}
            <div className="mt-4">
              <h5>
                <i className="bi bi-question-circle-fill"></i> {t("callInfo.path")}
              </h5>
              {visibleQuestions.map((qId) => {
                const question = mockPath.questions.find((q) => q.id === qId);
                return (
                  <div key={qId} className="mb-3 border p-3 rounded bg-light ">
                    <p className="fw-bold">{question.text}</p>
                    {question.answers.length > 0 ? (
                      question.answers.map((ans) => (
                        <div key={ans.id} className="form-check form-check-inline">
                          <input
                            className="form-check-input"
                            type="radio"
                            name={`question-${qId}`}
                            id={`answer-${ans.id}`}
                            value={ans.text}
                            checked={answers[qId] === ans.text}
                            onChange={() => handleAnswer(qId, ans)}
                          />
                          <label
                             className={`form-check-label ms-1`}
                            htmlFor={`answer-${ans.id}`}
                          >
                            {ans.text}
                          </label>
                        </div>
                      ))
                    ) : (
                      <p className="text-muted">🚫 لا توجد إجابات لهذا السؤال</p>
                    )}
                  </div>
                );
              })}
            </div>

            {/* زرار إرسال */}
            <div className="mt-4 text-center">
              <button type="submit" className="btn btn-primary">
                {t("common.submit")}
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}
