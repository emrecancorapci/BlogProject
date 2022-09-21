import React from 'react';
import axios from 'axios';
import {Button} from 'react-bootstrap';
import {getAuthHeader} from '../../Functions/User';

function CommentDeleteButton({id}) {
  const onDeleteComment = (id) => {
    const api = `https://localhost:7169/api/Comments/${id}`;
    const headers = getAuthHeader();

    axios.delete(api, headers)
        .then((request) => console.log(request))
        .catch((event) => console.log(event));
  };

  return (
    <Button
      variant="primary"
      onClick={() => onDeleteComment(id)}>
        Delete
    </Button>
  );
}

export default CommentDeleteButton;
