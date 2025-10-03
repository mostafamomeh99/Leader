import i18n from "i18next";
import { initReactI18next } from "react-i18next";
import LanguageDetector from "i18next-browser-languagedetector";


const resources = {
  en: {
    translation: {
      advancedFilters: {
  assignTo: "Assign Call To",
  assignToEmp: "Select Employee",
  scheduleDate: "Call Schedule Date",
  attemptDate: "Attempt Date (predictive)",
  uploadDate: "Upload Date",
},
      next:"Next",
      resetSearch:"clear",
      pervious:"Pervious",
  tableHeaders: {
      nationalId: "National ID",
      phone: "Phone Number",
      name: "Name",
      campaign: "Campaign",
      category: "Category",
      priority: "Priority",
      lastStatus: "Last Status",
      actions: "Actions"
    },
            uploadExcel:"Upload Excel File",
             circles: {
      one: "Successful Calls",
      two: "UnSuccessful Calls",
      three: "ReConnect Calls",
      call: "Call"
    },
  callcard: {
    "call": "Assigned",
    "inSystem": "In System",
    "follow": "Follow-up",
    "inFutureSystem": "In System (Predictive)",
    "followFuture": "Follow-up (Predictive)",
    "notAnswerFuture": "No Answer (Predictive)"
  },
       sidebar: {
      admin: "Admin",
      main: "Main",
      customers: "Customers",
      reports: "Reports",
      operations: "Operations",
      management: "Management",
      users:"user mangment",
      campines:"campaign Mangment",
      catgories:"Category Mangment",
       paths:"Paths",
       downloadBenefit:"Download Beneficiaries",
        Benefitfrom:"Beneficiaries from Download"
    },
      otp: {
        title: "Enter the code sent to your phone",
        submit: "Login",
      },
      forgot: {
  title: "Forgot Password?",
  submit: "Send Reset Link",
  success: "Reset link has been sent to your email.",
  error: "This email is not registered.",
},
callInfo: {
  title: "Call Information",
  status: "Call Status",
  campaign: "Campaign",
  beneficiaryName: "Beneficiary Name",
  nationalId: "National ID",
  phone: "Phone Number",
  titleInfoBeneficiary: "Beneficiary Information",
  path:"Call Path",
  placeholder: {
    name: "Enter beneficiary name",
    nationalId: "Enter national ID",
    phone: "Enter phone number",
  },
     formSubmitted: "Form submitted successfully",
}, common: {
      yes: "Yes",
      no: "No",
      submit: "Submit",
      update:"Update",
       choose:"Choose",
         successOperation: "Operation completed successfully!",
  failedOperation: "Operation failed, please try again.",
   noDataYet: "Not available yet",
      addUser:"Create Account",
    updateUser:"Edit Account"
    },
      login: {
            usernamePlaceholder: "Enter your username",
        passwordPlaceholder: "Enter your password",
        submit: "Login",
      },
      reset: {
  "title": "Reset Password",
  "password": "New Password",
  "confirmPassword": "Confirm Password",
  "submit": "Change Password",
  "success": "Password changed successfully",
  "error": "Failed to change password"
},operations: {
  // English
  selectCategory: "Please select category",
  chooseCategory: "Choose category",
  uploadTemplate:"Upload File",
  category1: "Category 1",
  category2: "Category 2",
  selectCampaign: "Please select campaign",
  chooseCampaign: "Choose campaign",
  campaign1: "Campaign 1",
  campaign2: "Campaign 2",
  selectPriority: "Please Choose priority",
  choosePriority: "Choose priority",
  high: "High",
  medium: "Medium",
  low: "Low",
  updateBeneficiaryData: "Do you want to update beneficiaries data ?",
  downloadInteractive: "Do you want to download in interactive mode?",
  callBackFailed: "Do you want to recall failed calls?",
  keepOldCall: "Keep old calls without adding new ones?",
  downloadTemplate: "Download Template",
      errorCategory: "please,select Category",
    errorCampaign: "please,select Campaign",
    errorPriority: "please,select Priority",
}
,tableUserHeaders: {
  empName: "Employee Name",
  phone: "Phone Number",
  empId: "Employee ID",
  extension: "Extension",
  username: "Username",
  email: "Email",
  team: "Team Name",
  role: "Job Role",
  status: "Employee Status",
  actions: "Actions",
  addUser:"Add User"
},tableCategoryHeaders:{
  category:"Category Name",
  categoryPath:"Category Path",
    actions: "Actions",
     addCategory:"Add Category",
          categoryName:"Category Name",
     categoryPath:"Category Path",
     data:"Category Name",
           noPath: "No path yet"
},Category:{
nameAr:"Name (Arabic)",
nameEn:"Name (English)",
pathName:"Path Category Name",
campainPerdictive:"The campaign in the predictive dialer",
},
tableCampainHeaders: {
  campaign: "Campaign Name",
  priority: "Campaign Priority",
  actions: "Actions",
  addCampaign:"Add Campaign",
    data:"Campaign Information",
},tablePathHeaders: {
  pathName: "Path Name",
  categoryName: "Category Name",
  actions: "Actions"
},path:{
  home: "Home Page",
  pathInfo: "Path Information",
  events: "Events",
  callStatusField: "Select the field representing call status",
  homeField: "Select the field representing home page",
  addPath:"Add Path"
},
       register: {
        title: "Create an Account",
        fullNameAr: "Full Name (Arabic)",
        fullNameEn: "Full Name (English)",
        nationalId: "National ID",
        email: "Email",
        phone: "Phone Number",
        password: "Password",
        confirmPassword: "Confirm Password",
        submit: "Register",
        success: "Registration successful!",
 forgotPassword: "Forgot your password?",
  username:"UserName",
        // rest come from database 
         extension: "Extension",
      manager: "Direct Manager",
      permissions: "Permissions",
      searchPermissions: "Search permissions...",
      managerOptions: {
        option1: "Direct Manager",
        option2: "Department Head",
        option3: "CEO",
      },
      permissionsList: {
        add:"Add Users",
        view: "View Users",
        edit: "Edit Users",
        delete: "Delete Users",
        manage:"Manage Users",
        access:"Access Settings",
        approve: "Approve Users",
      }
      },
              errors: {
   usernameRequired: "UserName is Required",
  usernameInvalid: "UserName is inValid",
  fullNameAr: "Arabic  Username is required",
  fullNameArInvalid: "Arabic  Username is invalid",
  fullNameEn: "English full name is not valid",
  emailRequired: "Email is required",
  email: "Invalid email address",
  nationalIdRequired: "National ID is required",
  nationalId: "National ID must be 14 digits",
  phoneRequired: "Phone number is required",
  phone: "Phone number must be 11 digits",
  passwordRequired: "Password is required",
  password: "Password must be at least 6 characters",
  confirmPasswordRequired: "Confirm password is required",
  confirmPassword: "Passwords do not match",
  otpRequired: "otp is required",
  otp: "otp is only numbers",
  extensionRequired: "Extension is required",
       extensionInvalid:"Extension is invalid",
      managerRequired: "Manager is required",
      permissionsRequired: "Select at least one permission",
        atLeastOneFilter: "Please enter at least one filter value",
        username:"invalid username"
}

    },
    
    
  },
  ar: {
    translation: {   
      advancedFilters: {
          assignToEmp: "اختر الموظف",
  assignTo: "جدولة المكالمة إلى",
  scheduleDate: "تاريخ جدولة المكالمة",
  attemptDate: "تاريخ محاولة الاتصال *خاص غير ناجح تنبؤى",
  uploadDate: "تاريخ التحميل",
},
            next:"التالى",
           resetSearch:"امسح",
      pervious:"السابق",    
       tableHeaders: {
      nationalId: "رقم الهوية",
      phone: "رقم الجوال",
      name: "الاسم",
      campaign: "الحملة",
      category: "التصنيف",
      priority: "الأولوية",
      lastStatus: "آخر حالة",
      actions: "الخيارات"
    },  tableCampainHeaders: {
  campaign: "اسم الحملة",
  priority: "أولوية الحملة",
  actions: "الخيارات",
  addCampaign:"إضافة حملة",
  data:"بيانات الحملة",
},    tablePathHeaders: {
  pathName: "اسم المسار",
  categoryName: "اسم التصنيفات",
  actions: "الخيارات"
}, path:{
addPath:"اضافه مسار"
},
          circles: {
      one: "مكالمات ناجحة",
      two: "مكالمات غير ناجحة",
      three: "مكالمات اعادة الاتصال",
      call: "مكالمة",
    },
      uploadExcel:"تصدير البيانات اكسيل",
      forgot: {
  title: "هل نسيت كلمة المرور؟",
  submit: "إرسال رابط إعادة التعيين",
  success: "تم إرسال رابط إعادة التعيين إلى بريدك الإلكتروني.",
  error: "هذا البريد غير مسجل.",
},

 callcard:{
        call:"مسندة",
        inSystem:"فى النظام",
        follow:"متابعة",
        inFutureSystem:"فى النظام (التنبؤى)",
        followFuture:" متابعة (التنبؤى)",
        notAnswerFuture:" لم يتم الرد (التنبؤى)"
      },operations: {
  // Arabic
  selectCategory: "فضلًا، اختر التصنيف",
  chooseCategory: "اختر التصنيف",
  category1: "تصنيف 1",
  category2: "تصنيف 2",
  selectCampaign: "فضلًا، اختر الحملة",
  chooseCampaign: "اختر الحملة",
  campaign1: "حملة 1",
  campaign2: "حملة 2",
  selectPriority: "يمكنك تحديد أولوية للاتصال",
  choosePriority: "اختر الأولوية",
  high: "عالية",
  medium: "متوسطة",
  low: "منخفضة",
  updateBeneficiaryData: "هل ترغب بتحديث بيانات المستفيدين ببيانات الملف المرفق؟",
  downloadInteractive: "هل ترغب بالتحميل في المسجل التفاعلي؟",
  callBackFailed: "هل ترغب بإعادة الاتصال بالمستفيدين الذين لم يتم الاتصال بهم من قبل بمكالمات ناجحة؟",
  keepOldCall: "ابقاء المكالمات المحفوظة سابقًا على حالها وعدم إضافة مكالمة جديدة؟",
  downloadTemplate: "تحميل قالب التحميل",
  uploadTemplate:"ارفع الملف",
      errorCategory: "من فضلك اختر التصنيف",
    errorCampaign: "من فضلك اختر الحملة",
    errorPriority: "من فضلك اختر الأولوية",
},
        sidebar: {
      admin: "المسؤول",
      main: "الرئيسية",
      customers: "العملاء",
      reports: "التقارير",
      operations: "العمليات",
      management: "الإدارة",
      campines:"ادارة الحملات",
      catgories:"ادارة التصنيفات",
       paths:"المسارات",
         users:"ادارة المستخدمين",
        downloadBenefit:"تحميل المستفيدين",
        Benefitfrom:"المستفيدين من التحميل"
    },callInfo: {
  title: "معلومات المكالمة",
  status: "حالة المكالمة",
  campaign: "الحملة",
  beneficiaryName: "اسم المستفيد",
    titleInfoBeneficiary: "معلومات المستفيد",
  nationalId: "رقم الهوية",
  phone: "رقم الجوال",
    path:"مسار المكالمة",
  placeholder: {
    name: "ادخل اسم المستفيد",
    nationalId: "ادخل رقم الهوية",
    phone: "ادخل رقم الجوال",
  },
        formSubmitted: "تم إرسال النموذج بنجاح",

},
      otp: {
        title: "ادخل الرمز المرسل الى جوالك",
        submit: "تسجيل الدخول",
      },path:{
 home: "الصفحة الرئيسية",
  pathInfo: "بيانات المسار",
  events: "الاحداث",
    callStatusField: "اختر الحقل الذى يعبر عن حالة المكالمة",
  homeField: "اختر الحقل الذى يعبر عن الصفحة الرئيسية",
        addPath:"اضافه مسار"
},
    login: {
        usernamePlaceholder: "ادخل اسم المستخدم",
        passwordPlaceholder: "ادخل كلمة المرور",
        submit: "تسجيل الدخول",
         forgotPassword: "هل نسيت كلمة المرور؟",
      },
      "reset": {
  "title": "إعادة تعيين كلمة المرور",
  "password": "كلمة المرور الجديدة",
  "confirmPassword": "تأكيد كلمة المرور",
  "submit": "تغيير كلمة المرور",
  "success": "تم تغيير كلمة المرور بنجاح",
  "error": "فشل تغيير كلمة المرور"
}
      ,

      register: {
        title: "إنشاء حساب جديد",
        fullNameAr: "الاسم الكامل (عربي)",
        fullNameEn: "الاسم الكامل (إنجليزي)",
        nationalId: "الرقم القومي",
        email: "البريد الإلكتروني",
        phone: "رقم الجوال",
        password: "كلمة المرور",
        confirmPassword: "تأكيد كلمة المرور",
        submit: "تسجيل",
        success: "تم التسجيل بنجاح!",
        username:"اسم المستخدم",
        // rest come from database 
             extension: "التحويلة",
      manager: "المدير المباشر",
      permissions: "الصلاحيات",
      searchPermissions: "ابحث في الصلاحيات...",
      managerOptions: {
        option1: "المدير المباشر",
        option2: "رئيس القسم",
        option3: "الرئيس التنفيذي",
      },
      permissionsList: {
        view: "عرض",
        edit: "تعديل",
        delete: "حذف",
        approve: "اعتماد",
        add:"اضافه",
        access:"وصول",
        manage:"ادارة",
          noDataYet: "لا يوجد حتى الآن"  
      }
        
        }, common: {
      yes: "نعم",
      no: "لا",
      submit: "إرسال",
      choose:"اختر",
      update:"تعديل",
        successOperation: "تمت العملية بنجاح!",
  failedOperation: "فشلت العملية، حاول مرة أخرى.",
    noDataYet: "لا يوجد حتى الآن"   ,
    addUser:"انشاء حساب",
    updateUser:"تعديل حساب"
    },
    tableUserHeaders: {
  empName: "اسم الموظف",
  phone: "رقم الجوال",
  empId: "رقم الموظف",
  extension: "رقم التحويلة",
  username: "اسم المستخدم",
  email: "البريد الإلكتروني",
  team: "اسم الفريق",
  role: "الدور الوظيفي",
  status: "حالة الموظف",
  actions: "الخيارات",
  addUser:"اضافه مستخدم"
},
tableCategoryHeaders:{
  category:"اسم التصنيف",
  categoryPath:"مسار التصنيف",
    actions: "الخيارات",
     addCategory:"اضافه تصنيف",
     categoryName:"اسم التصنيف",
     categoryPath:"مسار التصنيف",
         noPath: "لا يوجد مسار حتى الآن"
},Category:{
nameAr:" الاسم بالعربية",
nameEn:"الاسم بالانجليزية",
pathName:"اسم مسار التصنيف",
campainPerdictive:"الحملة فى المتصل التنبؤى",
data:"بيانات التصنيف"
},
 
          errors: {
    usernameRequired: "اسم المستخدم مطلوب",
       usernameInvalid:  "اسم المستخدم غير صالح",
  fullNameAr: "الاسم بالعربية مطلوب",
  fullNameArInvalid: "الاسم بالعربية غير صالح",
  fullNameEn: "الاسم بالإنجليزية غير صالح",
  emailRequired: "البريد الإلكتروني مطلوب",
  email: "البريد الإلكتروني غير صحيح",
  nationalIdRequired: "الرقم القومي مطلوب",
  nationalId: "الرقم القومي يجب أن يكون 14 رقمًا",
  phoneRequired: "رقم الجوال مطلوب",
  phone: "رقم الجوال يجب أن يكون 11 رقمًا",
  passwordRequired: "كلمة المرور مطلوبة",
  password: " كلمة المرور يجب أن تكون 6 أحرف على الأقل",
  confirmPasswordRequired: "تأكيد كلمة المرور مطلوب",
  confirmPassword: "كلمتا المرور غير متطابقتين",
    otpRequired: "الباسورد المتغير مطلوب",
  otp: "الباسورد المتغير غير مقبول",
     extensionRequired: "التحويلة مطلوبة",
     extensionInvalid:"التحويلة غير صالحه",
      managerRequired: "المدير مطلوب",
      permissionsRequired: "اختر صلاحية واحدة على الأقل",
        atLeastOneFilter: "من فضلك أدخل قيمة واحدة على الأقل في الفلتر",
        username:"اسم المستخدم غير صالح"
}
      },
      
    

    

  },
};


i18n.use(LanguageDetector).use(initReactI18next).init({
  resources,
  interpolation: { escapeValue: false },
    detection: {
       order: ["localStorage"],
      caches: ["localStorage"],
    },
    fallbackLng: "ar",
});

export default i18n;
