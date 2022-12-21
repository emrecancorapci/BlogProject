import {useFormik} from 'formik';
import axios from 'axios';
import {getToken} from '../../Functions/User';
import getApi from '../../Functions/Common/getApi';

// TODO Not working
function AddPost() {
  const userId = getToken() ? getToken().id : 1;
  const api = getApi('Posts');
  const fetchData = async (values) => await axios.post(api, values);

  const formik = useFormik({
    initialValues: {
      title: '',
      content: '',
      thumbnailUrl: '',
      addCommentsEnabled: true,
      addReactionsEnabled: true,
      categoryId: 1,
      authorId: userId,
    },
    onSubmit: (values) => {
      fetchData(values)
          .then((response) => {
            console.log(response);
          })
          .catch((event) => (
            console.log(event),
            console.log('Submitted.')));
    },
  });

  return (<div style={{padding: '.5rem'}}>
    <h1>Add Post</h1>
    <form onSubmit={formik.handleSubmit} style={{padding: '1rem'}}>
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
          type="text"
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
            value={formik.values.addCommentsEnabled}
            onChange={formik.handleChange}/>
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
            value={formik.values.addReactionsEnabled}
            onChange={formik.handleChange}/>
          <label className="form-check-label"
            htmlFor="addReactionsEnabled">
              Reactions Enabled
          </label>
        </div>
      </div>
      <div className="input-group mb-3">
        <span htmlFor='content' className='input-group-text'>Content</span>
        <textarea
          className='form-control'
          id='content'
          name='content'
          aria-label='Post'
          value={formik.values.content}
          onChange={formik.handleChange}/>
      </div>
      {/* {!error && <></>}
        {<Alert key={variant} variant={variant}>
          {errorText}
        </Alert>} */}
      <button className='btn btn-primary' type="submit">
          Submit
      </button>
    </form>
  </div>);
}

export default AddPost;
