import React, {useEffect, useState} from 'react';
import axios from 'axios';
import {Spinner, Stack} from 'react-bootstrap';
import PropTypes from 'prop-types';

import PostCard from './PostCard';

function Posts() {
  const [posts, setPosts] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [filterText, setFilterText] = useState('');

  // FETCHING
  useEffect(() => {
    axios('https://localhost:7169/api/Posts')
        .then((response) => setPosts(response.data))
        .catch((event) => console.log(event)) // Error logging
        .finally(() => setIsLoading(false)); // Set loading false
  }, []);


  // FILTER
  // On text changes at filter
  const onChangeFilter = ((event) =>
    setFilterText(event.target.value));

  const filtered = posts.filter((item) => {
    return Object.keys(item).some((key) =>
      item[key]
          .toString()
          .toLowerCase()
          .includes(filterText.toLowerCase()),
    );
  });

  return (<>
    <div>
      <input
        placeholder='Filter posts'
        value={filterText}
        onChange={onChangeFilter} />
    </div>
    <br />
    <div>
      {isLoading &&
                (<Spinner animation="border" role="status" />)}

      {<Stack gap={3}>
        {filtered.map((post, index) =>
          <div key={index}>
            <PostCard post={post} />
          </div>,
        )}
      </Stack>}
    </div>
  </>);
}

export default Posts;
