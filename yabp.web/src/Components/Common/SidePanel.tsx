import {Link} from 'react-router-dom';

function SidePanel() {
  return (
    <ul className='list-group'>
      <Link to={`/Posts/Add`}>
        <li className='list-group-item'>New Post</li>
      </Link>
      <li className='list-group-item'>Item</li>
      <li className='list-group-item'>Item</li>
      <li className='list-group-item'>Item</li>
    </ul>
  );
}

export default SidePanel;
