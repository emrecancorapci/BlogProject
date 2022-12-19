function getApi(request) {
  const api = `https://localhost:7082/api/${request}`;
  return api;
}

export default getApi;
