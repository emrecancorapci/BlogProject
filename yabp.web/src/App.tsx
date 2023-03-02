import { useEffect, useContext } from 'react';
import { getToken } from './Functions/User';

import Navigation from './Components/Common/Navigation';
import SidePanel from './Components/Common/SidePanel';
import Router from './Router';
import AuthContext from './Context/AuthContext';

function App (): JSX.Element {
  const { auth, setAuth } = useContext(AuthContext);

  useEffect(() => {
    const user = getToken();
    setAuth(user !== null);
  }, [auth]);

  // Add tabs to home page
  // Posts / My Posts / New Post

  return (<>
    <header>
      <div className='row'>
        <Navigation />
      </div>
    </header>

    <main className='container'>
      <div className='row justify-content-evenly'>
        <div className='col-lg-8 col-sm-12
          order-lg-1 order-sm-3 shadow bg-white rounded-2 border'>
          <div className='p-2 pt-3 m-3'>
            <Router/>
          </div>
        </div>
        <div className='col-lg-3 col-sm-12 order-2 p-3'>
          <SidePanel/>
        </div>
      </div>
    </main>

    <footer className='row bg-white border-top border-1 mt-5 pb-5'>
      <div className='container'>
        <div className='row justify-content-center'>
          <div className='col-auto'>
            Footer lol
          </div>
        </div>
      </div>
    </footer>
  </>);
}

export default App;
