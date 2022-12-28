import { useFormik } from 'formik';
import axios, { AxiosRequestConfig, AxiosResponse } from 'axios';

import { getToken, getAuthConfig } from '../../Functions/User';
import getApi from '../../Functions/Common/getApi';

import { CommentRequest } from '../../Interfaces/CommentRequest';

/**
 * @description Add comment component
 *
 * @param {Number} postId - Post id
 * @param {Number} parentId - Parent comment id
 * @return {JSX.Element} Add comment component
 */

function AddComment ({ postId, parentId }: {
  postId: number
  parentId?: number
}): JSX.Element {
  const user = getToken();
  const api = getApi('Comments');

  const config: AxiosRequestConfig = getAuthConfig();

  const fetchData: (values: CommentRequest) => Promise<AxiosResponse> =
  async (values: CommentRequest) => await axios.post(api, values, config);

  const formik = useFormik({
    initialValues: {
      content: '',
      authorId: user.id,
      postId,
      parentId
    },
    onSubmit: (values) => {
      fetchData(values)
        .then((response) => console.log(response))
        .catch((event) => console.log(event));
    }
  });

  return (
    <form onSubmit={formik.handleSubmit}>
      {user != null &&
      <div>
        <textarea
          className='form-control shadow-sm'
          id='content'
          name='content'
          rows={3}
          placeholder='Leave a comment'
          value={formik.values.content}
          onChange={formik.handleChange} />
        <div className='row justify-content-end'>
          <button className='col-auto btn text-white
          c-bg-dark border-0 fw-bold my-2 mx-3'
          type='submit'>
              Submit
          </button>
        </div>
      </div>}
    </form>
  );
}

export default AddComment;
