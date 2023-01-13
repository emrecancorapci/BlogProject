/**
 * @description Returns the API path for the  request
 *
 * @param {String} request - The request to be made
 * @return {String} The API path
 */

export default function getApi (request: string): string {
  console.log(process.env.REACT_APP_API_URL);
  console.log(process.env);
  const url = process.env.REACT_APP_API_URL;
  return url !== undefined ? url + request : '';
}
