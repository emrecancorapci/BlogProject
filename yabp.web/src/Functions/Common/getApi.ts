/**
 * @description Returns the API path for the  request
 *
 * @param {String} request - The request to be made
 * @return {String} The API path
 */

export default function getApi (request: string): string {
  const uri: string = import.meta.env.VITE_APP_API_URI
  return uri !== undefined ? uri + request : '';
}
