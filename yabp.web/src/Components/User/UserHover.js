import {useEffect, useState} from 'react';
import axios from 'axios';
import {LinkContainer} from 'react-router-bootstrap';
import {Popover, OverlayTrigger} from 'react-bootstrap';
import {FontAwesomeIcon} from '@fortawesome/react-fontawesome';
import {faUser} from '@fortawesome/free-solid-svg-icons';


function UserHover({id}) {
  const [user, setUser] = useState([]);

  useEffect(() => {
    axios(`https://localhost:7169/api/Users/${id}`)
        .then((response) => setUser(response.data))
        .catch((event) => console.log(event));
  }, [id]);

  const popover = (
    <Popover id="popover-basic">
      <Popover.Header>
        <div className="row align-items-center">
          <div className='col-2'>
            <img
              style={{
                height: '1.7rem',
                width: '1.7rem'}}
              src={user.profilePictureUrl}
              alt={`${user.name}'s profile picture`}/>
          </div>
          <div className='col'>
            <b>{user.name} {user.lastName}</b>
          </div>
        </div>
      </Popover.Header>
      <Popover.Body>
        <div className='row justify-content-center'>
          {user.about}
        </div>
      </Popover.Body>
    </Popover>
  );

  const username = (
    <LinkContainer to={`/Users/${id}`} style={{cursor: 'pointer'}}>
      <div><FontAwesomeIcon icon={faUser}/> {user.username}</div>
    </LinkContainer>
  );

  return (
    <OverlayTrigger
      placement="right"
      overlay={popover}>
      <div>
        {username}
      </div>
    </OverlayTrigger>
  );
}

export default UserHover;
