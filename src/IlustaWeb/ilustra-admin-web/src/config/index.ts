const development = process.env.NODE_ENV == "development";
const defaultApi = process.env.VUE_APP_API_BASE ?? "https://localhost:44354/";

// let originUrl = "";

// if (development) {
//     originUrl = defaultApi as string;
// } else {
//     originUrl = `${window.location.origin}${defaultApi}`;
// }

const config = {
    ApiUrl: defaultApi,
    version: "1.0.0"
}

export { config };