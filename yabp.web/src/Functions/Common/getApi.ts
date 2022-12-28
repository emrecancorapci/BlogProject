
/**
 * @description Returns the API path for the request
 *
 * @param {String} request - The request to be made
 * @return {String} The API path
 */

function getApi(request : string) : string {
  const api = `https://localhost:7082/api/${request}`;
  return api;
}

export default getApi;
