import {useEffect, useState} from 'react';
import axios from 'axios';
import {LinkContainer} from 'react-router-bootstrap';
import {Popover, OverlayTrigger} from 'react-bootstrap';
import {FontAwesomeIcon} from '@fortawesome/react-fontawesome';
import {faUser} from '@fortawesome/free-solid-svg-icons';

import getApi from '../../Functions/Common/getApi';


function UserHover({id}) {
  const [isLoading, setIsLoading] = useState(true);
  const [title, setTitle] = useState('');
  const [img, setImg] = useState('');
  const [user, setUser] = useState([]);

  const iconStyle = {
    // eslint-disable-next-line max-len
    color: 'rgba(34,0,59,1)',
  };
  useEffect(() => {
    if (!id) return;

    const api = getApi(`Users/${id}`);
    const fetchUser = async () => await axios(api);

    fetchUser()
        .then((response) => {
          if (response.data) {
            setUserData(response.data);
          }
        })
        .catch((event) => console.log(event));
  }, [id]);

  const setUserData = (data) => {
    setTitle(data.name ? data.name + ' ' + data.lastName :
    data.username);
    setImg(data.profilePictureUrl ? data.profilePictureUrl :
      '/img/common/blank_profile.png');

    setUser(data);
    setIsLoading(false);
  };

  const popover = (
    <Popover id="popover-basic">
      {isLoading && <div className='spinner-border' role='status' />}
      {!isLoading &&
      <><Popover.Header>
        <div className="row align-items-center">
          <div className='col-auto gx-2'>
            <img
              className='rounded-circle'
              style={{
                height: '2rem',
                width: '2rem',
              }}
              src={img}
              alt={`${title}'s profile picture`} />
          </div>
          <div className='col gx-2 fs-4'>
            {title}
          </div>
        </div>
      </Popover.Header><Popover.Body>
        <div className='row justify-content-center'>
          <p
            className='justify-content-center text-center'>
            {user.about}
          </p>
        </div>
      </Popover.Body></>}
    </Popover>
  );

  const username = (
    <LinkContainer to={`/Users/${user.id}`} style={{cursor: 'pointer'}}>
      <div className='c-tx-dark'>
        <FontAwesomeIcon icon={faUser} style={iconStyle}/>
        <spam className='px-2'>{user.username}</spam>
      </div>
    </LinkContainer>
  );

  return (
    <OverlayTrigger
      placement="right"
      overlay={popover}>
      <div className='row'>
        {username}
      </div>
    </OverlayTrigger>
  );
}

export default UserHover;
