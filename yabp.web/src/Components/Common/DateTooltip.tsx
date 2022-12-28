import { Tooltip, OverlayTrigger } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCalendar } from '@fortawesome/free-solid-svg-icons';

/**
 * Data tooltip with icon
 *
 * @param {string} date - Date
 * @return {JSX.Element} - Element
 */

function DateTooltip ({ date }: { date: string }): JSX.Element {
  const dateText = `${date.substring(0, 10)} - 
  ${date.substring(11, 8)}`;

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
