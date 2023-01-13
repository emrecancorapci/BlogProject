import { useFormik } from 'formik';
import axios, { AxiosResponse } from 'axios';
import { getToken, getAuthConfig } from '../../Functions/User';
import getApi from '../../Functions/Common/getApi';

import { PostRequest } from '../../Interfaces/PostRequest';

/**
 * @description Form to add a post
 *
 * @return {JSX.Element} Form element
 */

function AddPost (): JSX.Element {
  const userId = getToken() !== null ? getToken().id : 1;
  const api = getApi('Posts');

  const config = getAuthConfig();

  const fetchData: (values: PostRequest) => Promise<AxiosResponse> =
    async (values: PostRequest) => await axios.post(api, values, config);

  const formik = useFormik({
    initialValues: {
      title: '',
      content: '',
      thumbnailUrl: '',
      authorId: userId,
      addCommentsEnabled: true,
      addReactionsEnabled: true,
      categoryId: 1
    },
    onSubmit: (values: PostRequest) => {
      fetchData(values)
        .then((response) => {
          if (response.status !== 201) {
            throw new Error('Error' +
            ` ${response.status}: ${response.statusText}`);
          }
          console.log(response);
        })
        .catch((event) => { console.log(event); });
    }
  });

  return (<div className='p-2'>
    <h1 className='fw-bold'>Add Post</h1>
    <form onSubmit={formik.handleSubmit} style={{ padding: '1rem' }}>
      <div className="mb-3">
        <label htmlFor="title" className='form-label'>Post Title</label>
        <input
          className="form-control"
          id='title'
          name="title"
          type="text"
          placeholder="Title"
          value={formik.values.title}
          onChange={formik.handleChange} />
      </div>
      <div className="mb-3">
        <label htmlFor="title" className='form-label'>Thumbnail URL</label>
        <input
          className='form-control'
          id='thumbnailUrl'
          name="thumbnailUrl"
          type="url"
          placeholder="Thumbnail"
          value={formik.values.thumbnailUrl}
          onChange={formik.handleChange} />
      </div>
      <div className='row m-3'>
        {/* checks doesn't work */}
        <div className="form-check form-switch col-6">
          <input
            className="form-check-input"
            id='addCommentEnabled'
            name='addCommentEnabled'
            type="checkbox"
            onChange={formik.handleChange} />
          <label className="form-check-label"
            htmlFor="addCommentEnabled">
            Comments Enabled
          </label>
        </div>
        <div className="form-check form-switch col-6">
          <input
            className="form-check-input"
            id='addReactionsEnabled'
            name='addReactionsEnabled'
            type="checkbox"
            onChange={formik.handleChange} />
          <label className="form-check-label"
            htmlFor="addReactionsEnabled">
            Reactions Enabled
          </label>
        </div>
      </div>
      <div className="input-group mb-3">
        <span className='input-group-text'>Content</span>
        <textarea
          className='form-control'
          id='content'
          name='content'
          aria-label='Post'
          value={formik.values.content}
          onChange={formik.handleChange} />
      </div>
      <div className="row justify-content-end">
        <div className="col-auto">
          <button className='btn btn-primary' type="submit">
            Submit
          </button>
        </div>
      </div>
    </form>
  </div>);
}

export default AddPost;
