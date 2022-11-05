import {LinkContainer} from 'react-router-bootstrap';

function Navigation({title, auth, setAuth}) {
  const onClickLogout = () => {
    sessionStorage.removeItem('user');
    setAuth(false);
  };

  return (
    <nav className='navbar navbar-expand-lg navbar-dark bg-dark'>
      <div className='container'>
        <LinkContainer to={`/`}>
          <div className='navbar-brand'>{title}</div>
        </LinkContainer>
        <button
          className="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#headerNavbar"
          aria-controls="headerNavbar"
          aria-expanded="false"
          aria-label="Toggle navigation">
          <span className="navbar-toggler-icon"/>
        </button>

        <div className='collapse navbar-collapse' id='headerNavbar'>
          <div className="navbar-nav me-auto">
            <LinkContainer to={`/`}>
              <div className='nav-link'>Home</div>
            </LinkContainer>
          </div>
          <div className='d-flex offset-6'>
            {auth &&
            <button className='btn btn-light'
              onClick={() => onClickLogout()}>
              Logout
            </button>}
            {!auth &&
            <LinkContainer to={`/login`}>
              <div className='nav-link'>Login</div>
            </LinkContainer>}
          </div>
        </div>
      </div>
    </nav>
  );
}

export default Navigation;
