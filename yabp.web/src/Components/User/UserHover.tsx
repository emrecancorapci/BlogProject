import {useEffect, useState} from 'react';
import axios from 'axios';
import {Popover, OverlayTrigger} from 'react-bootstrap';
import {FontAwesomeIcon} from '@fortawesome/react-fontawesome';
import {faUser} from '@fortawesome/free-solid-svg-icons';
import {Link} from 'react-router-dom';

import getApi from '../../Functions/Common/getApi';

/**
 * @description A link to user's profile page in a popover
 *
 * @param {Number} id - Id of the user
 * @return {JSX.Element} Username with popover
 */

type User = {
  id: number;
  username: string;
  name: string;
  lastName: string;
  about: string;
  profilePictureUrl: string;
};

function UserHover({id} : {id:number}): JSX.Element {
  const [isLoading, setIsLoading] = useState(true);
  const [title, setTitle] = useState('');
  const [img, setImg] = useState('');
  const [user, setUser] = useState<User>({} as User);

  const iconStyle = {
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

  const setUserData = (data: User) => {
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
      {!isLoading && <div className='card'>
        <div className='card-header c-bg-lighter'>
          <div className="row align-items-center">
            <div className='col-auto'>
              <img
                className='rounded-circle'
                style={{
                  height: '1.7rem',
                  width: '1.7rem',
                }}
                src={img}
                alt={`${title}'s profile`} />
            </div>
            <div className='col gx-2 fs-5 fw-bold c-tx-dark'>
              {title}
            </div>
          </div>
        </div>
        <div className='card-body'>
          <p className='justify-content-center text-center'>
            {user.about}
          </p>
        </div>
      </div>}
    </Popover>
  );

  const username = (
    <Link to={`/Users/${user.id}`} style={{cursor: 'pointer'}}>
      <div className='c-tx-dark'>
        <FontAwesomeIcon icon={faUser} style={iconStyle}/>
        <span className='px-2'>{user.username}</span>
      </div>
    </Link>
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
