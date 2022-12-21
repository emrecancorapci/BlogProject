import {useState} from 'react';
import PropTypes from 'prop-types';
import axios from 'axios';
import {getToken} from '../../Functions/User';
import getApi from '../../Functions/Common/getApi';

function AddComment({postId, parentId}) {
  const [form, setForm] = useState([]);
  const [emptyFieldError, setEmptyFieldError] = useState('');

  const user = getToken();

  const onChangeInput = (event) => {
    event.target.name === 'content' ? setEmptyFieldError(''):1;
    setForm({...form, [event.target.name]: event.target.value});
  };

  const onSubmitForm = (event) => {
    event.preventDefault();

    form.authorId = user.id;
    form.postId = postId;
    form.parentId = parentId;

    if (form.content === '') {
      console.log('Fill the comment field.');
      setEmptyFieldError(...'Fill the comment field.');
      return false;
    }

    const api = getApi('Comments');

    axios.post(api, form)
        .then(function(response) {
          return response;
        })
        .catch(function(error) {
          return error;
        });
    console.log('Submit');
  };

  return (
    <form onSubmit={onSubmitForm}>
      {user != null &&
      <>
        <textarea
          className='form-control shadow-sm'
          rows='3'
          type='text'
          name='content'
          placeholder='Leave a comment'
          value={form.content}
          onChange={onChangeInput} />
        <div className='row justify-content-end'>
          <button className='col-auto btn text-white
          c-bg-dark border-0 fw-bold my-2 mx-3'>Submit</button>
        </div>
      </>}

      {emptyFieldError != '' &&
      <div className='alert alert-danger'>
        {emptyFieldError}
      </div>}
    </form>
  );
}

AddComment.propType = {
  user: PropTypes.object,
  content: PropTypes.string,
  postId: PropTypes.number,
  authorId: PropTypes.number,
};

export default AddComment;
