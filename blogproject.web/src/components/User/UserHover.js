import {useEffect, useState} from 'react';
import axios from 'axios';
import {LinkContainer} from 'react-router-bootstrap';
import {Popover, OverlayTrigger} from 'react-bootstrap';


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
          <div className='col-auto'>
            <img
              style={{
                height: '2rem',
                width: '2rem'}}
              src={user.profilePictureUrl}
              alt={`${user.name}'s profile picture`}/>
          </div>
          <div className='col-auto'>
            <b>{user.name} {user.lastName}</b>
          </div>
        </div>
      </Popover.Header>
      <Popover.Body>
        <div className='row justify-content-center'>
          {user.about}
        </div>
        <div className='row justify-content-center'>
          <div className='col-auto pt-2'>
            <LinkContainer to={`/Users/${id}`} style={{cursor: 'pointer'}}>
              <button className='btn btn-primary btn-sm'>
                    Show Profile
              </button>
            </LinkContainer>
          </div>
        </div>
      </Popover.Body>
    </Popover>
  );

  return (
    <OverlayTrigger trigger="click" placement="right" overlay={popover}>
      <>
        {user.username}
      </>
    </OverlayTrigger>
  );
}

export default UserHover;
