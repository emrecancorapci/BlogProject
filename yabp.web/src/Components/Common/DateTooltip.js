import {Tooltip, OverlayTrigger} from 'react-bootstrap';
import {FontAwesomeIcon} from '@fortawesome/react-fontawesome';
import {faCalendar} from '@fortawesome/free-solid-svg-icons';

function DateTooltip({date}) {
  const dateText = `${date.substr(0, 10)} - 
  ${date.substr(11, 8)}`;

  return (
    <OverlayTrigger
      placement={'top'}
      overlay={
        <Tooltip>
          {dateText}
        </Tooltip>
      }>
      <FontAwesomeIcon icon={faCalendar} />
    </OverlayTrigger>
  );
}

export default DateTooltip;
